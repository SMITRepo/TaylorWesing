function showMatterDetails(matterId) {
       $.ajax({
        url: `/matter/${matterId}`,
        type: 'GET',
        success: function (data) {
            $('#matter-detail').html(data);
            var myModal = new bootstrap.Modal(document.getElementById('matter-modal'));
            myModal.show();
        },
        error: function () {
            $('#matter-detail').html('Failed to load matter details');

        }
    });
}
    function loadMatters(clientId, sort, index, offset) {
        $.ajax({
            url: '/Client/'+clientId+'/Matters', 
            type: 'GET',
            data: {sort : sort, index : index, offset : offset },
            success: function (data) {
                // Replace the matters section with the response
                $('#matters-container').html(data);
            },
            error: function () {
                alert('Error loading matters. Please try again.');
            }
        });
    }

function GetMatters(index, clientId, offset) {
  $('li.page-item').removeClass('active');
    document.getElementById(index).classList.add( "active");
    const sort = $('#sort').val();   
    loadMatters(clientId, sort, index, offset);
}

function SortMatters(dropdown,clientId) {
    $('li.page-item').removeClass('active');
    document.getElementById("0").classList.add("active");
    const sort = dropdown.value;
    loadMatters(clientId, sort, 0, 10);
}

