var abp = abp || {};
(function () {
    /* CLOCK *****************************************/
    abp.clock = abp.clock || {};

    abp.clock.kind = 'Unspecified';

    abp.clock.supportsMultipleTimezone = function () {
        return abp.clock.kind === 'Utc';
    }

    abp.clock.timeZone = function () {
        return abp.setting.get('Abp.Timing.TimeZone');
    }

    // Normalize Date object or date string to standard string format that will be sent to server
    abp.clock.normalizeToString = function (date) {
        if (!date) {
            return date;
        }

        var dateObj = date instanceof Date ? date : new Date(date);
        if (isNaN(dateObj)) {
            return date;
        }

        function padZero(num) {
            return num < 10 ? '0' + num : num;
        }

        var addZulu = false;
        if (abp.clock.supportsMultipleTimezone()) {
            var timeZone = abp.clock.timeZone();
            var now = new Date();
            var formattedDate = now.toLocaleString('en-US', { timeZone: timeZone, timeZoneName: 'longOffset' });
            var match = formattedDate.match(/GMT([+-]\d+)/);
            var targetOffsetHours = match ? parseInt(match[1], 10) : 0;
            var dateObj = new Date(dateObj.getTime() - (targetOffsetHours * 60 * 60 * 1000));
            addZulu = true;
        }

        // yyyy-MM-DDTHH:mm:ss
        return dateObj.getFullYear() + '-' +
            padZero(dateObj.getMonth() + 1) + '-' +
            padZero(dateObj.getDate()) + 'T' +
            padZero(dateObj.getHours()) + ':' +
            padZero(dateObj.getMinutes()) + ':' +
            padZero(dateObj.getSeconds()) + (addZulu ? 'Z' : '');
    };

    // Default options for toLocaleString
    abp.clock.toLocaleStringOptions = abp.clock.toLocaleStringOptions || {
        "year": "numeric",
        "month": "long",
        "day": "numeric",
        "hour": "numeric",
        "minute": "numeric",
        "second": "numeric"
    };

    // Normalize date string to locale date string that will be displayed to user
    abp.clock.normalizeToLocaleString = function (dateString, options) {
        if (!dateString) {
            return dateString;
        }

        var date = new Date(dateString);
        if (isNaN(date)) {
            return dateString;
        }

        var culture = abp.localization.currentCulture.cultureName;
        options = options || abp.clock.toLocaleStringOptions;
        if (abp.clock.supportsMultipleTimezone()) {
            var timezone = abp.clock.timeZone();
            if (timezone) {
                return date.toLocaleString(culture, Object.assign({}, options, { timeZone: timezone }));
            }
        }
        return date.toLocaleString(culture, options);
    }
})();
