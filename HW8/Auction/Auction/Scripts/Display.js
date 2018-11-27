function ajax_call(id) {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: '/Items/BidResults/' + id,
        data: { id: id },
        success: displayResults,
        error: errorOnAjax
    });
}

var interval = 1000 * 5; // where X is your timer interval in X seconds

window.setInterval(ajax_call(id), interval);

function displayResults(data) {
    $('#allBids').empty();

    var item = document.getElementById("#allBids");
    data.arr.forEach(function(item) {

        $('#allBids').append(item);
    });

    console.log(data);
};

function errorOnAjax() {
    console.log("Ajax Error");
};


