var abp = abp || {};
$(function () {
    abp.modals.meetingCreate = function () {
        var initModal = function (publicApi, args) {
            var $form = publicApi.getForm();
            $form.find('button[type="submit"]').on('click', function (e) {
                $form.handleDatepicker('input[type="hidden"][data-start-date], input[type="hidden"][data-end-date], input[type="hidden"][data-date]');
            });
        };

        return {
            initModal: initModal
        }
    };
});
