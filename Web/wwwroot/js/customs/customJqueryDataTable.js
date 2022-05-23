jQuery.csDataTable = function (tableId, columns, dataUrl, processing, serverSide) {

    //$.ajax({
    //    type: "Post",
    //    url: dataUrl,
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //    success: function (data) {
    debugger;
    tableId.DataTable({
        autoWidth: false,
        "columns": columns,
        "processing": processing,
        "serverSide": serverSide,
        //"aaData": data
        "ajax": {
            "url": dataUrl,
            "type": "POST",
            "dataType": "json",
            "dataSrc": ""
        }
        //});
        ////datasource = data;
        //$('#example').DataTable({
        //    "aaData": JSON.parse(data.d),
        //    "columns": [{ "data": "Firstname" }, { "data": "Lastname" }]
        //});

        //},
        //error: function(err) {
        //    alert(err);
        //}
    });



    return;
}
jQuery.jqGrids = function (tableId, columns, dataUrl) {
    tableId.jqGrid({
        url: dataUrl,
        mtype: "GET",
        datatype: "json",
        //colModel: [
        //    { label: 'OrderID', name: 'OrderID', key: true, width: 75 },
        //    { label: 'Customer ID', name: 'CustomerID', width: 150 },
        //    { label: 'Order Date', name: 'OrderDate', width: 150 },
        //    { label: 'Freight', name: 'Freight', width: 150 },
        //    { label: 'Ship Name', name: 'ShipName', width: 150 }
        //],
        colModel: columns,
        viewrecords: true,
        height: 250,
        rowNum: 20,
        pager: "#jqGridPager"
    });
}

jQuery.telerikKendoGrid = function (tableId, methodType, readDataUrl, columnsArr, isPageable, isSortable, isFilterable, schemaFields) {
    tableId.kendoGrid({
        dataSource: {
            type: methodType,
            transport: {
                read: readDataUrl
            },
            schema: {
                model: {
                    fields: schemaFields
                }
            },
            pageSize: 20,
            serverPaging: true,
            serverFiltering: true,
            serverSorting: true
        },
        height: 550,
        filterable: isFilterable,
        sortable: isSortable,
        pageable: isPageable,
        columns: columnsArr
    });
    return;
}

jQuery.telerikKendoGrid = function (tableId, methodType, readDataUrl, editDataUrl, columnsArr, isPageable, isSortable, isFilterable, pkColumnName, schemaFields, gridEditable = "popup") {
    tableId.kendoGrid({
        dataSource: {
            type: methodType,
            transport: {
                read: readDataUrl
            },
            update: {
                url: editDataUrl,
                dataType: methodType
            },
            schema: {
                model: {
                    id: pkColumnName,
                    fields: schemaFields
                }
            },
            pageSize: 20,
            serverPaging: true,
            serverFiltering: true,
            serverSorting: true
        },
        height: 550,
        filterable: isFilterable,
        sortable: isSortable,
        pageable: isPageable,
        columns: columnsArr,
        editable: gridEditable
    });
    return;
}


jQuery.telerikKendoGrid = function (tableId, methodType, readDataUrl, editDataUrl, createDataUrl, columnsArr, isPageable, isSortable, isFilterable, pkColumnName, schemaFields, gridEditable = "popup") {
    tableId.kendoGrid({
        dataSource: {
            type: methodType,
            transport: {
                read: readDataUrl
            },
            update: {
                url: editDataUrl,
                dataType: methodType
            },
            create: {
                url: createDataUrl,
                dataType: methodType
            },
            schema: {
                model: {
                    id: pkColumnName,
                    fields: schemaFields
                }
            },
            pageSize: 20,
            serverPaging: true,
            serverFiltering: true,
            serverSorting: true
        },
        height: 550,
        filterable: isFilterable,
        sortable: isSortable,
        pageable: isPageable,
        toolbar: ["create"],
        columns: columnsArr,
        editable: gridEditable
    });
    return;
}

jQuery.jqueryTable = function (tableId, tableTitle, fields, actions, isLoadNow,isPaging = false, pageSize = 10) {
    tableId.jtable({
        title: tableTitle,
        actions: actions,
        fields: fields,
        paging: isPaging,
        pageSize: pageSize,
        formSubmitting: function (event, data) {
           
            var input = document.createElement('input');
            input.id = "Edit-PIpId";
            input.name = "PIpId";
            input.value = "5a51b694-24c6-004e-9477-8797ba9d9cd4";
            input.hidden = true;
            document.getElementById(data.form[0].id).appendChild(input);
            return true;
        }
    });

    if (isLoadNow) {
        tableId.jtable('load');
    }
}

jQuery.buildPersonDropdown = function (result, dropdown, emptyMessage) {
    // Remove current options
    dropdown.html('');
    // Add the empty option with the empty message
    dropdown.append('<option value="">' + emptyMessage + '</option>');
    // Check result isnt empty
    if (result != '') {
        // Loop through each of the results and append the option to the dropdown
        $.each(result, function (k, v) {
            var personFullName = v.PName.concat(' ', v.PSurname);
            dropdown.append('<option value="' + v.PId + '">' + personFullName + '</option>');
        });
    }
}