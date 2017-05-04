$(document).ready(function () {

    $('.inventory').click(function () {
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: $(this).data('request-url'),
            success: function (result) {
                $('#result').html(result);
                $(".inventory-list").click(function () {
                    $.ajax({
                        type: 'GET',
                        url: $(this).data('request-url'),
                        dataType: 'html',
                        success: function (result) {
                            $(".edit").html(result);
                        }
                    });
                    $.ajax({
                        type: 'GET',
                        url: $(this).data('request-url'),
                        dataType: 'html',
                        success: function (result) {
                            $(".delete").html(result);
                        }
                    });
                });
            }
        });
    });
    $('.new-inventory').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: '@Url.Action("NewInventory")',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                var resultMessage = 'You\'ve added a new inventory item to the database!<br>Id: ' + result.inventoryId + '<br>Name: ' + result.name + '<br>Description: ' + result.description + '<br>Price: ' + result.price;
                $('#result6').html(resultMessage);
            }
        });
    });
});