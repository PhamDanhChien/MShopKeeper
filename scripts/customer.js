$(document).ready(function (){
    new Customer();
});

class Customer {
    constructor() {
        this.loadData();
        this.initEvent();
        this.formMode = null;
    }

    loadData() {
        $("#table tbody").empty();

        $.ajax({
            url: "https://localhost:44351/api/customer",
            method: "GET",
            dataType: "json",
        }).done(function (res) {
            $.each(res, function (index, item) {
                let row = $('<tr><td>' + item.CustomerId + '</td>' +
                    '<td>' + item.CustomerName + '</td>' +
                    '<td>' + item.CustomerPhone + '</td>' +
                    '<td>' + item.CustomerBirth + '</td>' +
                    '<td>' + item.CustomerGroup + '</td>' +
                    '<td>' + item.CustomerNote + '</td>' +
                    '<td>' + item.CustomerState + '</td></tr>');
                $("#table tbody").append(row);
            });
        }).fail(function () {
            alert("Lấy dữ liệu không thành công.");
        });
    }

    initEvent() {
        $("#table tbody").on("click", "tr", this.trClick);
        $("#btn-add").click(this.btnAddClick.bind(this));
        $("#btn-edit").click(this.btnEditClick.bind(this));
        $("#btn-del").click(this.btnDelClick.bind(this));
        $("#btn-dialog-close").click(this.btnDialogCloseClick);
        $("#btn-dialog-cancel").click(this.btnDialogCloseClick);
        $("#btn-dialog-save").click(this.btnDialogSaveClick.bind(this));
    }

    trClick() {
        $(this).addClass("selected");
        $(this).siblings().removeClass("selected");
    }

    btnDialogCloseClick() {
        $("#modal").hide();
        $("#dialog-customer").hide();
    }

    btnAddClick() {
        this.formMode = "POST";
        $("#dialog-customer input, #dialog-customer textarea").val(null); 
        $("#modal").show();
        $("#dialog-customer").show();
    }

    btnEditClick() {
        this.formMode = "PUT";
        if ($("#table tbody tr.selected").length == 0) {
            alert("Bạn chưa chọn nhân viên nào!");
            return;
        }

        let rowId = $("#table tbody tr.selected td:first").text();
        $.ajax({
            url: "https://localhost:44351/api/customer/" + rowId,
            method: "GET"
        }).done(function (customer) {
            $("#customer-id").val(customer.CustomerId);
            $("#customer-name").val(customer.CustomerName);
            $("#customer-phone").val(customer.CustomerPhone);
            $("#customer-birth").val(customer.CustomerBirth);
            $("#customer-group").val(customer.CustomerGroup);
            $("#customer-note").val(customer.CustomerNote);
            $("#customer-state").val(customer.CustomerState);

            $("#modal").show();
            $("#dialog-customer").show();
        }).fail({

        });
    }

    btnDialogSaveClick() {
        let self = this;
        let temp = {
            CustomerId: $("#customer-id").val(),
            CustomerName: $("#customer-name").val(),
            CustomerPhone: $("#customer-phone").val(),
            CustomerBirth: $("#customer-birth").val(),
            CustomerGroup: $("#customer-group").val(),
            CustomerNote: $("#customer-note").val(),
            CustomerState: $("#customer-state").val()
        }
        $.ajax({
            url: "https://localhost:44351/api/customer",
            method: self.formMode,
            data: temp
        }).done(function () {
            self.formMode = null;
            self.loadData();
        }).fail(function () {
            alert(self.formMode + ": Gửi dữ liệu không thành công");
        });

        $("#modal").hide();
        $("#dialog-customer").hide();
    }

    btnDelClick() {
        let self = this;
        if ($("#table tbody tr.selected").length == 0) {
            alert("Bạn chưa chọn khách hàng nào!");
            return;
        }

        let rowId = $("#table tbody tr.selected td:first").text();
        if ( !confirm("Bạn có chắc chắn muốn xóa khách hàng có mã: \"" + rowId + "\" không?") ) {
            return;
        }

        $.ajax({
            url: "https://localhost:44351/api/customer/" + rowId,
            method: "DELETE",
        }).done(function () {
            self.loadData();
        }).fail(function () {
            alert("Xóa không thành công");
        });
    }
}
/*
let customerData = [
    {
        customerId: "KH001",
        customerName: "Nguyễn Hoàng Long",
        customerPhone: "032963652",
        customerBirth: "25/10/1999",
        customerGroup: "",
        customerNote: "",
        customerState: "Đang theo dõi",
    },
    {
        customerId: "KH002",
        customerName: "Trần Thị Thu Hương",
        customerPhone: "0165321825",
        customerBirth: "03/05/1996",
        customerGroup: "",
        customerNote: "",
        customerState: "Đang theo dõi",
    },
    {
        customerId: "KH003",
        customerName: "Nguyễn Văn Hùng",
        customerPhone: "0315698745",
        customerBirth: "12/02/1997",
        customerGroup: "",
        customerNote: "",
        customerState: "Đang theo dõi",
    }
]
*/