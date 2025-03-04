var abp = abp || {};
$(function () {
    abp.modals.meetingEdit = function () {
        var initModal = function (publicApi, args) {
            var $form = publicApi.getForm();
            $form.find('button[type="submit"]').on('click', function (e) {
                $form.handleDatepicker('input[type="hidden"][data-hidden-datepicker]');
            });
        };

        return {
            initModal: initModal
        }
    };
});
