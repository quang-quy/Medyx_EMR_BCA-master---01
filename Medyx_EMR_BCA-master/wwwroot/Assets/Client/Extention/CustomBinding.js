
ko.bindingHandlers.GioiTinh = {
    init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var GT = valueAccessor();
        var ret = "NỮ";
        if (GT)
            ret = "NAM";

        element.innerHTML = ret;
    },
    update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var GT = valueAccessor();
        var ret = "NỮ";
        if (GT)
            ret = "NAM";

        element.innerHTML = ret;
    }
}
ko.bindingHandlers.dataTablesForEach = {
    page: 0,
    init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var options = ko.unwrap(valueAccessor());
        ko.unwrap(options.data);
        if (options.dataTableOptions.paging) {
            valueAccessor().data.subscribe(function (changes) {
                var table = $(element).closest('table').DataTable();
                ko.bindingHandlers.dataTablesForEach.page = table.page();
                table.destroy();
            }, null, 'arrayChange');
        }
        var nodes = Array.prototype.slice.call(element.childNodes, 0);
        ko.utils.arrayForEach(nodes, function (node) {
            if (node && node.nodeType !== 1) {
                node.parentNode.removeChild(node);
            }
        });
        return ko.bindingHandlers.foreach.init(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext);
    },
    update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var options = ko.unwrap(valueAccessor()),
            key = 'DataTablesForEach_Initialized';
        ko.unwrap(options.data);
        var table;
        if (!options.dataTableOptions.paging) {
            table = $(element).closest('table').DataTable();
            table.destroy();
        }
        ko.bindingHandlers.foreach.update(element, valueAccessor, allBindings, viewModel, bindingContext);
        table = $(element).closest('table').DataTable(options.dataTableOptions);
        if (options.dataTableOptions.paging) {
            if (table.page.info().pages - ko.bindingHandlers.dataTablesForEach.page == 0)
                table.page(--ko.bindingHandlers.dataTablesForEach.page).draw(false);
            else
                table.page(ko.bindingHandlers.dataTablesForEach.page).draw(false);
        }
        if (!ko.utils.domData.get(element, key) && (options.data || options.length))
            ko.utils.domData.set(element, key, true);
        return { controlsDescendantBindings: true };
    }
};


ko.bindingHandlers.displayDateDDMMYYYFromJsonDate = {
    init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var jsonDate = valueAccessor();
        var ret = '';
        if (jsonDate != '') {
            var date = new Date(parseInt(jsonDate.substr(6)));
            var dd = date.getDate();
            if (dd <= 9)
                dd = "0" + dd.toString();
            var MM = date.getMonth() + 1; // Tháng trong js bắt đầu từ 0->11
            if (MM <= 9)
                MM = "0" + MM.toString();
            var yyyy = date.getFullYear();
            ret = dd + "/" + MM + "/" + yyyy;
        }
        element.innerHTML = ret;
    },
    update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var jsonDate = valueAccessor();
        var ret = '';
        if (jsonDate != '') {
            var date = new Date(parseInt(jsonDate.substr(6)));
            var dd = date.getDate();
            if (dd <= 9)
                dd = "0" + dd.toString();
            var MM = date.getMonth() + 1; // Tháng trong js bắt đầu từ 0->11
            if (MM <= 9)
                MM = "0" + MM.toString();
            var yyyy = date.getFullYear();
            ret = dd + "/" + MM + "/" + yyyy;
        }
        element.innerHTML = ret;
    }
}
ko.bindingHandlers.datepicker = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        //initialize datepicker with some optional options
        var options = allBindingsAccessor().datepickerOptions || {};
        $(element).datepicker(options);

        //handle the field changing
        ko.utils.registerEventHandler(element, "change", function () {
            var observable = valueAccessor();
            observable($(element).val());
            if (observable.isValid()) {
                observable($(element).datepicker("getDate"));

                $(element).blur();
            }
        });

        //handle disposal (if KO removes by the template binding)
        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $(element).datepicker("destroy");
        });

        ko.bindingHandlers.validationCore.init(element, valueAccessor, allBindingsAccessor);

    },
    update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var value = ko.utils.unwrapObservable(valueAccessor());

        //handle date data coming via json from Microsoft
        if (String(value).indexOf('/Date(') == 0) {
            value = new Date(parseInt(value.replace(/\/Date\((.*?)\)\//gi, "$1")));
        }

        current = $(element).datepicker("getDate");

        if (value - current !== 0) {
            $(element).datepicker("setDate", value);
        }
    }
};