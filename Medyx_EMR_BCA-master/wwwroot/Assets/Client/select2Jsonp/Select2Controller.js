var selectController = {
    init: function () {
        selectController.LoadData();
    },
    LoadData: function () {
        //The url we will send our get request to
        var attendeeUrl = '/Client/PhongKham/GetAttendees';
        var pageSize = 2;
        $('#attendee').select2(
        {
            placeholder: 'Enter name',
            //Does the user have to enter any data before sending the ajax request
            minimumInputLength: 0,
            multiple: true,
            allowClear: true,
            ajax: {
                //How long the user has to pause their typing before sending the next request
                quietMillis: 150,
                //The url of the json service
                url: attendeeUrl,
                dataType: 'jsonp',
                //Our search term and what page we are on
                data: function (term, page) {
                    return {
                        pageSize: pageSize,
                        pageNum: page,
                        searchTerm: term
                    };
                },
                results: function (data, page) {
                    //Used to determine whether or not there are more results available,
                    //and if requests for more data should be sent in the infinite scrolling                    
                    var more = (page * pageSize) < data.Total;
                    return { results: data.Results, more: more };
                }
            }
                , formatResult: function (results) {
                    return '<div class="row"> <div class="col-md-1" > </div>' +
            '<div style="border:1px solid" class="col-md-5">' + results.id + '</div>' +
            '<div  style="border-bottom:1px solid;border-top:1px solid;border-right:1px solid" class="col-md-5" >' + results.text + '</div>' +
            ' <div class="col-md-1" ></div></div>';
                }
        });
        $('.select2-header').append('<li class="select2-header-dept-0 select2-header select2-header-selectable" ><div class="select2-header-label" ><div class="row"> <div class="col-md-1" > </div>' +
            '<div style="border:1px solid" class="col-md-5">' + 'Mã khoa' + '</div>' +
            '<div  style="border-bottom:1px solid;border-top:1px solid;border-right:1px solid" class="col-md-5" >' + 'Tên khoa' + '</div>' +
            ' <div class="col-md-1" ></div></div></div></li>');

    }


}
selectController.init();