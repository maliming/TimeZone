$(function () {
    var l = abp.localization.getResource('TimeZoneApp');

    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Meetings/CreateModal',
        modalClass: 'meetingCreate'
    });
    var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Meetings/EditModal',
        modalClass: 'meetingEdit'
    });

    var dataTable = $('#MeetingsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(timeZoneApp.meetings.meeting.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('TimeZoneApp.Meetings.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    },
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('TimeZoneApp.Meetings.Delete'),
                                    confirmMessage: function (data) {
                                        return l('MeetingDeletionConfirmationMessage', data.record.subject);
                                    },
                                    action: function (data) {
                                        timeZoneApp.meetings.meeting
                                            .delete(data.record.id)
                                            .then(function() {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Subject'),
                    data: "subject"
                },
                {
                    title: l('StartTime') + ' / ' + l('StartTime'),
                    data: "startTime",
                    render: function (data, type, row) {
                        return abp.clock.normalizeToLocaleString(row.startTime) + ' ➡️ ' + abp.clock.normalizeToLocaleString(row.endTime);
                    }
                },
                {
                    title: l('ActualStartTime'),
                    data: "actualStartTime",
                    dataFormat: "datetime"
                },
                {
                    title: l('CanceledTime'),
                    data: "canceledTime",
                    render: function (data, type, row) {
                        return data ? abp.clock.normalizeToLocaleString(data) : 'N/A';
                    }
                },
                {
                    title: l('Description'),
                    data: "description"
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewMeetingButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
