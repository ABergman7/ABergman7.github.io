
function ajax_call(id) {
   // var id = @Model.ItemID
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: '/Items/BidResult/' + id,
        data: { id: id },
        success: displayResults,
        error: errorOnAjax
    });
}

var interval = 1000 * 5; // where X is your timer interval in X seconds

window.setInterval(ajax_call(id), interval);


function displayResults(data) {



    //put at the bottom row
    var item = document.getElementById("allBids")
    data.forEach(function (item) {

        $('#allBids').find('tbody').append("<tr><td>" + item["Price"] + "</td><td>" + item["Buyername"] + "</td></tr>");

    });

    console.log(data);
};

function errorOnAjax() {
    console.log("Ajax Error");
};

