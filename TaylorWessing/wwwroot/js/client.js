$(document).ready(function(){

    document.addEventListener("DOMContentLoaded", function () {
        const rows = document.querySelectorAll(".clickable-row");

        rows.forEach(row => {
            row.addEventListener("mouseenter", function () {
                this.style.backgroundColor = "#f1f1f1"; // Light gray on hover
            });

            row.addEventListener("mouseleave", function () {
                this.style.backgroundColor = ""; // Reset background color
            });
        });
    });


    $('#search-button').on('click', function () {

        if ($('#search-term').val().trim() !== '') {

            const searchTerm = $('#search-term').val();
            const sortType = $('#sort').val();
                       
            $.ajax({
                url: '/client/search',
                type: 'GET',
                data: { term: searchTerm, sort: sortType },
                success: function (data) {
                    $('#result-container').html(data);
                },
                error: function (data) {
                    $('#ErrorDisplay').html('<strong>Error retrieving data. Please try again later.</strong>');
                }
            });
        }
        else
        {
            $('#ErrorDisplay').html('<strong>Please enter a value in the text box.</strong>');
        }

    });





});

function GetClients(searchTerm, sortType,index, offset) {
    $.ajax({
        url: '/client/search',
        type: 'GET',
        data: { term: searchTerm, sort: sortType, index: index, offset: offset },
        success: function (data) {
            $('#result-container').html(data);
        },
        error: function () {
            $('#ErrorDisplay').html('<strong>Error retrieving data. Please try again later.</strong>');
        }
    });

}
