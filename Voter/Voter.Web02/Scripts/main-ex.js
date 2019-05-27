$(document).ready(function () {
    $('.date-picker').datepicker({
        format: "dd.mm.yyyy",
        autoclose: true,
        todayHighlight: true
    });
});

/* live select2 */
$(document).ready(function () {
    $('select.live-picker').each(function () {
        var $self = $(this);

        $self.select2({
            minimumInputLength: 0,
            allowClear: true,
            placeholder: "Hledat...",
            ajax: { 
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                url: $self.data('api-url'),
                dataType: 'json',
                delay: 250,
                params: {
                    contentType: 'application/json'
                },
                data: function (params) {
                    var query = {
                        top: 20,
                        displayName: params.term
                    }
                    return JSON.stringify(query);
                },
                processResults: function (data, params) {
                    params.page = params.page || 1;
                    var select2Data = $.map(data.data.items, function (obj) {
                        obj.id = obj.value;
                        obj.text = obj.text;
                        return obj;
                    });
                    return {
                        results: select2Data,
                        pagination: {
                            more: false
                        }
                    };
                }
            }
        });
    });

    //$("select.live-picker").on("changed.bs.select",
    //    function () {
    //        var $self = $(this);

    //        var $inner = $self.prev().find('.inner');
    //        var $option = $inner.find('a');

    //        $inner.removeClass('dropdown-menu');
    //        $option.addClass('dropdown-item');
    //    });
});