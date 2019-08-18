/*
Appetizer.JS 1.0
Creator : Rokybul Imrose, Manager ICT Application Management, SCIB. 
Create Date: 10IV2016
Description:
This helper class facilitate for manipulating HTML controls under MVC environment. This will help to initialize controls for various 
data operations like DB read, JSON operation and Memory Database. This will also be powering the div to control to json object mapping dynamically. 
Enjoy and enhance, but do not forget to put version increment, version date and the version creator name is in given format.

Version Number  Version Date    Creator Name            Changes 
01              10IV2016        Rokybul Imrose          First created
02
*/

var appetizer = {
    appName: "resumelink 3.0",

    //appTool contains small utilities/configurations for code manipulation 
    tools: {
        validationType: {
            isNotEmpty: 0,
            isGreterThen: 1,
            isLessThen: 2
        },
        operationType: {
            ShowRecord: 0,
            SaveRecord: 1,
            UpdateRecord: 2,
            DeleteRecord: 3
        },
        getCVal: function (type, controlName) { //type for kendo detection
            return $("#" + controlName).val();
        },
        redirectToAction: function (controllerName, actionName) {
            return "/" + actionName + "/" + controllerName;
        },
        getJsonStringFromJsonObject: function (jsonObj) {
            return JSON.stringify(jsonObj);
        },
        getJsonObject: function (jsonString) {
            return JSON.parse(jsonString);
        },
        getImage: function (photo, style) {
            
            if (photo != null) { // only base 64 src with style
                if (photo == 0) {
                    return '<img id="tmpImage" src="../Images/placeholder.png" ' + '" style="' + style + '" />';
                } else {
                    photo = base64js.fromByteArray(photo);
                    return '<img id="tmpImage" src="' + 'data:image/jpg;base64,' + photo + '" style="' + style + '" />';
                }
            } else {
                return '<img id="tmpImage" src="../Images/placeholder.png" ' + '" style="' + style + '" />';
            }
        },
        getImageSrc: function (photo) { // only base 64 src
            if (photo != null) {
                if (photo == 0) {
                    return '../Images/placeholder.png';
                } else {
                    photo = base64js.fromByteArray(photo);
                    return 'data:image/jpg;base64,' + photo;
                }
            } else {
                return '../Images/placeholder.png';
            }
        },
        cancelGridEdit: function (divNames, kendoGrid) {
            if (typeof divNames != 'undefined' && divNames != null) {
                var arrayDivs = divNames.split(',');
                for (i = 0; i < arrayDivs.length; i++) {
                    var divID = document.getElementById(arrayDivs[i]);
                    setControlsValue(new appetizer.jsonObject(),
                        divID,
                        true,
                        true); //why reset & clear together needed...
                }
            }

            if (typeof kendoGrid != 'undefined' && kendoGrid != null) {
                appetizer.grid.getSelectedUID[kendoGrid] = "";
            }
        },

        // Reset the page , clear divs input and reset datasource of other databound controls
        resetPage: function (divNames, kendoGrids, kendoMultis, kendoListViews, kendoTree, kendoUpload, focusControl) {
            //
            if (typeof divNames != 'undefined' && divNames != null) {
                var arrayDivs = divNames.split(',');
                for (i = 0; i < arrayDivs.length; i++) {
                    var divID = document.getElementById(arrayDivs[i]);
                    setControlsValue(new appetizer.jsonObject(),
                        divID,
                        true,
                        true); //why reset & clear together needed...
                }
            }

            if (typeof kendoGrids != 'undefined' && kendoGrids != null) {
                //
                var arrayGrids = kendoGrids.split(',');
                for (i = 0; i < arrayGrids.length; i++) {
                    $("#" + arrayGrids[i]).data('kendoGrid').dataSource.data([]);
                    appetizer.grid.getSelectedUID[arrayGrids[i]] = "";
                }
            }

            if (typeof kendoMultis != 'undefined' && kendoMultis != null) {
                var arrayMulti = kendoMultis.split(',');
                for (i = 0; i < arrayMulti.length; i++) {
                    $("#" + arrayMulti[i]).data('kendoMultiSelect').value([]); //.dataSource.data([]);;
                }
            }

            if (typeof kendoListViews != 'undefined' && kendoListViews != null) {
                var arrayList = kendoListViews.split(',');
                for (i = 0; i < arrayList.length; i++) {
                    $("#" + arrayList[i]).data('kendoListView').dataSource.data([]);;
                }
            }

            if (typeof kendoTree != 'undefined' && kendoTree != null) {
                var arrayTree = kendoTree.split(',');
                for (i = 0; i < arrayTree.length; i++) { //work
                    $("#" + arrayTree[i]).data('kendoListView').dataSource.data([]);;
                }
            }

            if (typeof kendoUpload != 'undefined' && kendoUpload != null) {
                var arrayUp = kendoUpload.split(',');
                for (i = 0; i < arrayUp.length; i++) { //work
                    $("#" + arrayUp[i]).data('kendoListView').dataSource.data([]);;
                }
            }
            //if (typeof primaryKeyTags != 'undefined') {
            //    var arrayPK = primaryKeyTags.split(',');
            //    for (i = 0; i < arrayPK.length; i++) { //work
            //        $("#" + arrayPK[i]).data('kendoListView').dataSource.data([]);;
            //    }
            //}
            if (typeof focusControl != 'undefined' && focusControl != null) $('#' + focusControl).focus();
        },
        getDate: function (value) {

            if (value == '' || value == null) {
                return null;
            } else {
                var pattern = /Date\(([^)]+)\)/;
                var results = pattern.exec(value);
                var dt = new Date(parseFloat(results[1]));
                return dt.getFullYear() +
                    "-" +
                    ("0" + (dt.getMonth() + 1)).slice(-2) +
                    "-" +
                    ("0" + dt.getDate()).slice(-2);
            }
        },
        getDateTime: function (value) {
            if (value == '' || value == null) {
                return null;
            } else {
                var pattern = /Date\(([^)]+)\)/;
                var results = pattern.exec(value);
                var dt = new Date(parseFloat(results[1]));
                var hours = dt.getHours() > 12 ? dt.getHours() - 12 : dt.getHours();
                var am_pm = dt.getHours() >= 12 ? "PM" : "AM";
                hours = hours < 10 ? "0" + hours : hours;
                var minutes = dt.getMinutes() < 10 ? "0" + dt.getMinutes() : dt.getMinutes();
                var seconds = dt.getSeconds() < 10 ? "0" + dt.getSeconds() : dt.getSeconds();
                time = hours + ":" + minutes + ":" + seconds + " " + am_pm;
                return dt.getFullYear() +
                    "-" +
                    ("0" + (dt.getMonth() + 1)).slice(-2) +
                    "-" +
                    ("0" + dt.getDate()).slice(-2) +
                    " " +
                    time;
            }
        },
        testTmp: function getTmp() {
            return "";
        }
    },
    ajaxLoder: {
        showPleaseWait: function () {
            var styleModal = document.createElement('style');
            styleModal.type = 'text/css';
            styleModal.innerHTML =
                '.modal { display: none; position: fixed; z-index: 1000; top: 0; left: 0; height: 100%; ' +
                'width: 100%; background: rgba( 255, 255, 255, .8 ) url(\'http://i.stack.imgur.com/FhHRx.gif\') 50% 50% no-repeat; }';
            document.getElementsByTagName('head')[0].appendChild(styleModal);

            var styleModalHide = document.createElement('style');
            styleModalHide.type = 'text/css';
            styleModalHide.innerHTML = '.modal .show { display: none; }';
            document.getElementsByTagName('head')[0].appendChild(styleModalHide);

            $('body').append('<div id="modalDiv" class="modal"></div>');
            $('#modalDiv').addClass('modal show');
        },
        hidePleaseWait: function () {
            $('#modalDiv').removeClass("show");
        },
    },

    //Datoperations are done here, requires action url, json data, comand type(Add,Edit,Delete,Search,Reset) and a rebind control after post back  
    crudPost: function (controllerName, actionName, jsonObject, operationType, callbackFn) {
        //
        var postData = JSON.stringify(jsonObject);
        var jdataObj = { _operationType: operationType, jdata: postData }; //{ _operationType: 1, 'data': postData }
        var jsdataObj = JSON.stringify(jdataObj);

        $.ajax({
            type: "POST",
            url: "/" + controllerName + "/" + actionName,
            data: jsdataObj,
            contentType: "application/json",
            processData: false,
            success: function (response, status, jqXHR) {

                if (response != null && response.success) callbackFn(response, true);
                else callbackFn(response, false);
            },
            error: function (jqXHR, status, error) {

                var err = jqXHR.responseText;
                err = err.substring(err.indexOf("<title>"), err.indexOf("<meta")).replace('<title>', '')
                    .replace('<meta', '');
                callbackFn(err, false);
            },
            complete: function (jqXHR, status) {
                //
            }
        });
    },
    actionCall: function (actionURL, jsonObject, type, callbackFn) {
        $.ajax({
            //type: "POST",
            url: actionURL,
            type: type,
            data: jsonObject,
            dataType: 'json',
            success: function (response, status, jqXHR) {
                // 
                if (callbackFn != null || callbackFn != undefined) {
                    if (response != null && response.success) callbackFn(response, true);
                    else callbackFn(response, false);
                }
            },
            error: function (jqXHR, status, error) {

                if (callbackFn != null || callbackFn != undefined) {
                    var err = jqXHR.responseText;
                    // err = err.substring(err.indexOf("<title>"), err.indexOf("<meta")).replace('<title>', '').replace('<meta', '');
                    callbackFn(err, false);
                }
            }
        });
    },

    actionCallWithFileUpload: function (actionURL, jsonObject, type, callbackFn) {
        $.ajax({
            url: actionURL,
            type: type,
            data: jsonObject,
            cache: false,
            contentType: false,
            processData: false,
            success: function (response, status, jqXHR) {
                // 
                if (callbackFn != null || callbackFn != undefined) {
                    if (response != null && response.success) callbackFn(response, true);
                    else callbackFn(response, false);
                }
            },
            error: function (jqXHR, status, error) {

                if (callbackFn != null || callbackFn != undefined) {
                    var err = jqXHR.responseText;
                    // err = err.substring(err.indexOf("<title>"), err.indexOf("<meta")).replace('<title>', '').replace('<meta', '');
                    callbackFn(err, false);
                }
            }
        });
    },

    message: {
        showError: function (base, msg, duration) {
            if (duration == null || duration == undefined) duration = true;
            $(base).iziModal({
                title: "Error",
                subtitle: msg,
                iconClass: 'fa fa-exclamation-triangle',
                headerColor: '#BD5B5B',
                width: 600,
                timeout: duration,
                autoOpen: false,
                timeoutProgressbar: true
            });
            $(base).iziModal('setSubtitle', msg);
            $(base).iziModal('open');
        },
        showInfo: function (base, msg, duration) {
            if (duration == null || duration == undefined) duration = true;
            $(base).iziModal({
                title: "Information",
                subtitle: msg,
                iconClass: 'fa fa-info-circle',
                headerColor: '#5bbd72',
                width: 600,
                timeout: duration,
                autoOpen: false,
                timeoutProgressbar: true
            });
            $(base).iziModal('setSubtitle', msg);
            $(base).iziModal('open');
        },
        showWarning: function (base, msg, duration) {
            if (duration == null || duration == undefined) duration = true;
            $(base).iziModal({
                title: "Warning",
                subtitle: msg,
                iconClass: 'fa fa-info-circle',
                headerColor: '#fc9928',
                width: 600,
                timeout: duration,
                autoOpen: false,
                timeoutProgressbar: true
            });
            $(base).iziModal('setSubtitle', msg);
            $(base).iziModal('open');
        },
        showConfirmMini: function (msg) {
            swal({
                title: "Error!",
                text: "Here's my error message!",
                type: "error",
                confirmButtonText: "Cool"
            });
        },
        showConfirm: function (msg, callbackFn) {
            swal({
                title: "Are you sure?",
                text: msg,
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes",
                closeOnConfirm: false,
                closeOnCancel: true
            },
                function (isConfirm) {
                    swal.close();
                    callbackFn(isConfirm);
                });
        }
    },

    //From validations object to validate forms inputs at client side. Usage : Add Validation and check validate status before crudPost 
    formValidation: function () {
        this.valObj = {};
        this.add = function (controlName, validationType, message) {

            var info = [];
            info.push(validationType);
            info.push(message);
            this.valObj[$('#' + controlName)[0].id] = info;
        };
        this.validate = function () {

            var isValid = true;
            var focusControl = null;
            for (var key in this.valObj) {
                if (this.valObj.hasOwnProperty(key)) {
                    var arrVal = this.valObj[key];
                    if (arrVal[0] == 0) {
                        var cVal = $('#' + key).val();
                        if (cVal == "") { // if control value is empty // need to add other validation logic - B/H
                            $('#e' + key).html(arrVal[1]);
                            $('#e' + key).addClass('showError');
                            $('#e' + key).removeClass('hideError');
                            if (focusControl == null) focusControl = $('#' + key);
                            isValid = false;
                        } else {
                            $('#e' + key).addClass('hideError');
                            $('#e' + key).removeClass('showError');
                        }
                    }
                }
            }
            //focusControl.focus();
            if (focusControl != null) $('#' + focusControl[0].id).focus()
            this.valObj = {};
            return isValid;
        };
    },
    //Custom Grid
    cgrid: {
        addDataToTheGridFromDiv: function (gridId, divId, primaryKeyTag) {

            var $tbody;
            $tbody = gridId.find("tbody");
            $tbody.find("tr[data-role='emptyRow']").remove();

            var divData = appetizer.div.getJsonObjectFromDiv(divId, primaryKeyTag);
            if (divData.id != "") {
                var id = parseInt(divData.id);
                gridId.updateRow(id, divData);
            } else {
                divData.id = gridId.count() + 1;
                gridId.addRow(divData);
            }


        },

        editGridData: function (e, targetDiv, primaryKeyTag) {
            $("#id").val(e.data.id);
            var jsonString = JSON.stringify(e.data.record);
            var jObj = JSON.parse(jsonString);
            appetizer.div.loadDivControlFromJson(jObj, primaryKeyTag);
        },

        GetAllDataFromGrid: function (gridID) {
            var grid = $('#' + gridID);
            var gridData = gj.grid.private.GetAll(grid);
            var jsonArray = { "data": [] };
            for (i = 0; i < gridData.length; i++) {
                jsonArray.data.push(gridData[i].record);
            }

            return jsonArray;
        },

        //Delete Custom Grid Data
        deleteGridData: function (e) {
            var grid = $(e.view.grid.selector);
            appetizer.cgrid.removeRow(grid, e.data.id);
        },

        removeRow: function (grid, rowId) {
            var t = gj.grid.private.getRowById(grid, rowId)
            return t && t.remove(), this
        }


    },
    //Kendo grid operations 
    grid: {
        getSelectedUID: {}, //new Array(), //multipule grid problem , discuss with team
        selectedRow: {
            //Kendo grid is a mapper to set form input controls values based on ORM principal. Works on grid edit button click.
            loadDataToDivControl: function (e, _this, primaryKeyTag) {

                var dataItem = _this.dataItem($(e.currentTarget).closest("tr"));

                appetizer.grid.getSelectedUID = {};
                appetizer.grid.getSelectedUID[_this.element[0].id] = dataItem.uid;

                //if ($("#" + primaryKeyTag).val() == "")
                $("#" + primaryKeyTag).val(dataItem[primaryKeyTag]);

                var jsonString = JSON.stringify(dataItem);
                var jObj = JSON.parse(jsonString);

                appetizer.div.loadDivControlFromJson(jObj); //??
            },

            //Delete row from grid
            deleteItem: function (e, _this, g) {

                if (confirm("Do you really want to delete this record?")) {
                    var ff = $(e.currentTarget).closest("tr");
                    var dataItem = _this.dataItem($(e.currentTarget).closest("tr"));

                    if (dataItem.modType == "A") {
                        _this.dataSource.remove(dataItem);
                        _this.dataSource.sync();
                    } else {
                        dataItem.modType = "D";
                        var grid = $("#" + g).data("kendoGrid");
                        var currenRow =
                            grid.table.find("tr[data-uid='" +
                                dataItem.uid +
                                "']"); // var editButton = $(currenRow).find(".k-grid-edit");
                        currenRow.hide();
                    }
                }
            }
        },
        getJSONObject: function (grid) {

            var val = $("#" + grid).data("kendoGrid").dataSource.view();
            return val; //JSON.parse(JSON.stringify(val));
        },
        getRowCount: function (grid) {

            var displayedData = $("#" + grid).data("kendoGrid").dataSource.data();
            return displayedData.length;
        },
        getSelectedRow: function (grid) { //rework
            var displayedData = $("#" + grid).data()
            return displayedData;
        },
        getSelectedIndex: function (grid) { //rewok
            var grid = $("#" + grid).data("kendoGrid");
            var selectedRow = grid.select();
            var index = selectedRow.index();
            return index;
        },
        getDataSource: function (grid) {
            var displayedData = $("#" + grid).data("kendoGrid");
            return displayedData;
        },
        getDataSourceView: function (grid) { //rework
            var displayedData = $("#" + grid).data("kendoGrid").data().kendoGrid.dataSource.view();
            return displayedData;
        },
        getDataSourceViewJSONString: function (grid) {
            var displayedData = $("#" + grid).data().kendoGrid.dataSource.view();
            var displayedDataAsJSON = JSON.stringify(displayedData);
            return displayedDataAsJSON;
        },

        //Load data to grid using action url       
        loadGridDataFromAction: function (grid, controllerName, actionName, jsonData) {

            $.ajax({
                type: "POST",
                url: "/" + controllerName + "/" + actionName,
                data: JSON.stringify(jsonData),
                contentType: "application/json",
                success: function (result) {
                    var Kgrid = $("#" + grid).data("kendoGrid");
                    Kgrid.dataSource.data(result);

                },
                error: function () {
                    alert("An Error ocured!");
                }

            });
        },

        //Load data to grid using json data
        loadGridDataFromJson: function (grid, data) {

            var grc = $("#" + grid).data('kendoGrid');
            grc.dataSource.data(data);
        }
    },

    //Kendo list view operations  
    list: {
        selectedRow: {
            getCurrentID: function (e, _this) { // need to /*rework*/ ... purpose to get listview current index

                return _this.dataItem($(e.currentTarget).closest("tr"));
            },

            // need to /*rework*/ ... purpose to set data to div controls on listview clickable object clicked
            loadDataToDivControl: function (listView, targetDiv, primaryKeyFirst) {

                var lvData = $("#" + listView).data("kendoListView");
                var dataItems = lvData.dataSource.view();

                var jo = new appetizer.jsonObject();
                setControlsValue(jo, targetDiv);
                var jsondata = jo.get();
                jo.add(primaryKeyFirst, dataItems.length);
                return jo.get();
            },
        },

        //Load kendo listview using action url or json data. if controler is null then json data used
        loadData: function (listViewName, controler, action, jdata) {

            var lvd = $("#" + listViewName).data("kendoListView");
            if (controler != null) {
                $.post('/' + controler + '/' + action,
                    jdata,
                    function (data, result) {

                        lvd.dataSource.data(data['Data']);
                    });
            } else {
                lvd.dataSource.data(jdata);
            }
        },

        // Get kendo listview datasource 
        getDataSource: function (listViewName) {

            var lvd = $("#" + listViewName).data("kendoListView");
            return lvd.dataSource.data();
        },

        // Get kendo listview datasource row count
        getRowCount: function (grid) {

            var displayedData = $("#" + grid).data("kendoListView").dataSource.data();
            return displayedData.length;
        },
    },

    // Check box list using kendo listview 
    checkList: {
        getCheckboxListValues: function (checkBoxList, primaryKey) {

            var data = $("#" + checkBoxList).data("kendoListView").dataSource.view();
            var checkboxes = $("#" + checkBoxList).find("input:checkbox:checked");

            for (var i = 0; i < data.length; i++) {
                data[i]['modType'] = "D";
                for (var j = 0; j < checkboxes.length; j++) {
                    if (data[i][primaryKey] == $("#" + checkBoxList).find("input:checkbox:checked")[j].id) {
                        data[i]['modType'] = "DA";
                    }
                }
            }

            return data;
        }
    },

    // Option button list using kendo listview 
    radioList: {
        getRedioButtonListValues: function (radioButtonList) {
            var radios = $("#" + radioButtonList).find("input:radio:checked");
            return radios[0].id;
        }
    },
    radioListSelected: { 
        getRedioButtonListValues: function (radioButtonList,name) {
            var radios = $("#" + name).find("input:radio:checked");
        }
    },
    //Kendo multi select operations 
    multi: {
        multiObjs: {},
        delVals: {},
        addVals: {},
        //Get json data object from multi select control
        getJSON: function (multiSelectName, foreignKeyTag) {
            //
            var _foreignKeyTag = $("#" + foreignKeyTag);
            var jsonStr = '{"jsonRec":[]}';
            var obj = JSON.parse(jsonStr);

            var mls = $("#" + multiSelectName).data("kendoMultiSelect");

            for (var i = 0; i < this.delVals[multiSelectName].length; i++) {
                var jo = new appetizer.jsonObject();
                var iVal = this.delVals[multiSelectName][i];
                jo.add(mls.options.dataValueField, iVal); //if not null //why 0 needed
                jo.add(_foreignKeyTag[0].id, parseInt(_foreignKeyTag.val())); //if not null //why 0 needed
                jo.add("modType", "D");
                obj['jsonRec'].push(jo.get());
                jo.empty();
            }

            for (var i = 0; i < this.addVals[multiSelectName].length; i++) {
                var jo = new appetizer.jsonObject();
                var iVal = this.addVals[multiSelectName][i];
                jo.add(mls.options.dataValueField, iVal);
                jo.add(_foreignKeyTag[0].id, parseInt(_foreignKeyTag.val())); //if not null //why 0 needed
                jo.add("modType", "A");
                obj['jsonRec'].push(jo.get());
                jo.empty();
            }

            return obj.jsonRec;
        },


        //Load jason data to a multi select control 
        loadDataFromJson: function (multi, data) {
            // ;
            //var multiSelect = $("#" + multi).data('kendoMultiSelect');
            var multiSelect = document.getElementById(multi);
            var mulVal = [];
            for (var i = 0; i < data.length; i++) {
                mulVal.push(data[i][multiSelect.options.dataValueField]);
            }
            multiSelect.value(mulVal);
            appetizer.multi.multiObjs[multi] = mulVal;
        }
    },

    //Load DropDownList Data
    dropDown: {
        loadDataFromJson: function (dropdown, controllerName, actionName, jsonData) {
            $.ajax({
                type: "POST",
                url: "/" + controllerName + "/" + actionName,
                data: JSON.stringify(jsonData),
                contentType: "application/json",
                success: function (result) {
                    var ddl = $("#" + dropdown).data("kendoDropDownList");
                    ddl.dataSource.data(result);

                },
                error: function () {
                    alert("An Error ocured!");
                }

            });

            //$.post('/' + controler + '/' + action, JSON.stringify(jsondata), function (result) {
            //var ddl = $("#" + dropdown).data("kendoDropDownList");
            //ddl.dataSource.data(result);
            //});
        }

    },

    //Div inputes/labels operations 
    div: {

        // Add div inputs to a selected grid
        addItemToGrid: function (grid, parentDiv, primaryKeyTag, foreignKeyTag, focusControl, isClear) {

            var jo = new appetizer.jsonObject();
            var productsGrid = $('#' + grid).data('kendoGrid');
            var dataSource = productsGrid.dataSource;


            if ($("#" + primaryKeyTag).val() == "") $("#" + primaryKeyTag).val(0);
            if ($("#" + foreignKeyTag).val() == "") $("#" + foreignKeyTag).val(0);
            var _foreignKeyTag = $("#" + foreignKeyTag);


            var _parentDiv = document.getElementById(parentDiv);
            setControlsValue(jo, _parentDiv, isClear);
            jo.add(_foreignKeyTag[0].id, _foreignKeyTag.val()); //if not null //why 0 needed

            var jsonval = jo.get();
            var found = "";

            var girdCols = dataSource.options.schema.model.fields;
            var findItems = $("#" + grid).data("kendoGrid").dataSource.data();

            //Find DUPLICATE ROWS

            for (i = 0; i < findItems.length; i++) {
                for (var key in jsonval) {
                    if (jsonval[key] != appetizer.grid.getSelectedUID[grid]) {
                        if (key != primaryKeyTag) {
                            var row = findItems[i][key];
                            if (jsonval[key] == row) found += true.toString() + ' ';
                            else found += false.toString() + ' ';
                        }
                    }
                }
                if (found != "" && found.search('false') == -1) {

                    if (jsonval["modType"] == "D") {
                        dataItem.modType = "A";
                        var grid = $("#" + g).data("kendoGrid");
                        var currenRow =
                            grid.table.find("tr[data-uid='" +
                                findItems.uid +
                                "']"); // var editButton = $(currenRow).find(".k-grid-edit");
                        currenRow.show();
                    } else {
                        alert('Duplicate Entry Found');
                    }
                    return;
                }
                found = "";
            }

            //REPLACE OLD ITEMS

            var isReplaced = false;
            var items = $("#" + grid).data("kendoGrid").dataSource.data();
            for (i = 0; i < items.length; i++) {
                if (items[i].uid == appetizer.grid.getSelectedUID[grid]) {

                    jo.add("modType", "E");
                    //;
                    for (var key in jsonval) {
                        //;
                        if (key == "modType") items[i][key] = "E";
                        else items[i][key] = jsonval[key];
                    }
                    isReplaced = true;
                    //break;
                }
            }

            //ADD NEW ITEM
            if (isReplaced == false) {
                jo.add("modType", "A");
                var jsonval = jo.get();
                dataSource.add(jsonval);
            }
            appetizer.grid.getSelectedUID[grid] = "";

            dataSource.sync();
            jo.empty();
            if (focusControl != null) $('#' + focusControl).focus();
        },

        // Add div inputs to a selected list view
        addItemToListView:
            function (listView, parentDiv, primaryKeyFirst, focusControl) { //neeed to work later  /*rework*/ 

                var jo = new appetizer.jsonObject();
                var productsGrid = $(listView).data('kendoListView');
                var dataSource = productsGrid.dataSource;

                setControlsValue(jo, parentDiv);

                jo.add(primaryKeyFirst, dataSource._total);
                var jsonval = jo.get();

                var dataItems = dataSource.view();
                for (var i = 0; i < dataSource._data.length; i++) {
                    var row = dataItems[i][duplicateCheckField];
                    if (jsonval[duplicateCheckField] == row) {
                        alert('Duplicate Entry Found');
                        return;
                    }
                    //break;
                }

                dataSource.add(jsonval);
                dataSource.sync();
                if (focusControl != null) $('#' + focusControl).focus();
            },

        //Get all inputs in div and return json
        getJsonObjectFromDiv: function (divName, primaryKeyTag) {
            
            if ($("#" + primaryKeyTag).val() == "") $("#" + primaryKeyTag).val(0);
            var jo = new appetizer.jsonObject();
            var _divName = document.getElementById(divName);
            setControlsValue(jo, _divName, false);
            var jsonval = jo.get();
            return jsonval;
        },

        // Set control values from given jason       
        loadDivControlFromJson: function (jsonVal, primaryKeyTag) {
            //;
            var jObj = jsonVal;// JSON.parse(jsonString);
            for (var key in jObj) {
                //;
                if (key == "ProductiveAssets") {
                    
                }
                //  if (jObj.hasOwnProperty(key)) {
                if (key != "") {

                    var fieldName = key;
                    var cellValue = (jObj[key]);
                    var node = $('#' + key);
                    var nodeName = key;

                    //var iNumber = Number(cellValue);

                    if (fieldName == primaryKeyTag) {
                        //
                        if (cellValue == "")
                            cellValue = 0;

                        $("#" + primaryKeyTag).val(cellValue);
                    }
                    else {
                        // 
                        if (isDropDownList() == 'k-dropdown-wrap k-state-default') {
                            var dropdownlist = $("#" + fieldName).data("kendoDropDownList");
                            dropdownlist.value(jObj[fieldName.replace('Name', 'ID')]);
                        }
                        else if (isDateTimePicker() == "k-widget k-datetimepicker k-header") {
                            //
                            var datepicker = $('#' + fieldName).data("kendoDateTimePicker");
                            var dateVal = new Date(cellValue);
                            var dateString = dateVal.toLocaleDateString() + ' ' + dateVal.toLocaleTimeString();
                            datepicker.value(dateVal);
                        }
                        else if (isDateTimePicker() == "k-widget k-datetimepicker k-header") {
                            //
                            var datepicker = $('#' + fieldName).data("kendoDateTimePicker");
                            var dateVal = new Date(cellValue);
                            var dateString = dateVal.toLocaleDateString() + ' ' + dateVal.toLocaleTimeString();
                            datepicker.value(dateVal);
                        }
                        else if (isRadioButton() == "radio") {
                            $("input[name=" + nodeName + "][value=" + cellValue + "]").attr('checked', 'checked');
                           
                        }
                        else if (isMultiSelect() == 'select-multiple') {
                            var multiSelect = $(node.selector).data("kendoMultiSelect");
                            cellValue = (jObj[key+"Id"]);
                            var mulValue = JSON.parse("[" + cellValue + "]");
                            multiSelect.value(mulValue);
                        }
                        else {
                           
                            $('#' + fieldName).val(cellValue);
                            $('#l' + fieldName).html(cellValue);
                        }
                    }
                }
            }

            function isNumeric(n) {
                return !isNaN(parseFloat(n)) && isFinite(n);
            }

            function isDropDownList() {
                var classNameKendoControl = "";
                if (node[0] != null) {
                    if (node[0].previousSibling != null) {
                        classNameKendoControl = node[0].previousSibling.className;
                    }
                }
                return classNameKendoControl;
            }
            function isRadioButton() {
                var classNameKendoControl = "";
                if (node[0] == null) {
                    var nodee = document.getElementsByName(nodeName);
                    if (nodee[0] != null) {
                        if (nodee[0].type == "radio")
                        classNameKendoControl = nodee[0].type;
                    }
                }
                return classNameKendoControl;
            }
            function isMultiSelect() {
               // 
                var classNameKendoControl = "";
                if (node[0] != null) {
                    var nodee = document.getElementsByName(nodeName);
                    if (nodee[0] != null) {
                        if (nodee[0].type == "select-multiple")
                            classNameKendoControl = nodee[0].type;
                    }
                }
                return classNameKendoControl;
            }
            function isDateTimePicker() {
                var classNameKendoControl = "";
                if (node[0] != null) {
                    if (node[0].parentNode != null) {
                        classNameKendoControl = node[0].parentNode.parentNode.className;
                    }
                }
                return classNameKendoControl;
            }
        }
    },

    // A array oblect waraper  /*rework*/ 
    memArray: {
        arrayOnject: function () {
            this.arraySource = [];
            this.add = function (value) {
                this.arraySource.push(value);
            }
        }
    },

    // Memory JSON onject
    //memJSON: {
    jsonObject: function () {
        this.jsonObj = {};
        this.add = function (name, value) {
            //
            this.jsonObj[name] = value;
        };
        this.addBatch = function (jsonObj) {
            //;
            for (var key in jsonObj) {
                if (jsonObj.hasOwnProperty(key)) {
                    if (key != "") {
                        this.add(key, jsonObj[key]);
                    }
                }
            }
        };
        this.get = function () {
            return this.jsonObj;
        };
        this.getString = function () {
            var json = JSON.stringify(this.jsonObj);
            return json;
        };
        this.empty = function () {
            this.jsonObj = {};
        }
    },

    // Memory Kendo Datasource /*rework*/
    memoryKendoDatasource: {
        create: function () {
            //;
            this.source = null;
            if (this.source == null) this.source = new kendo.data.DataSource({ data: [] });

            this.addItem = function (items) {
                this.source.add(items);
            };
            this.addFilter = function (filters) {
                this.source.filter(filters);
            };
            this.hasCell = function (duplicateCheckField, sourceItems) {

                var dataItems = this.source.view();
                var valFound = false;
                for (var i = 0; i < this.source._data.length; i++) {
                    if (dataItems.length != 0) {
                        var row = dataItems[i][duplicateCheckField];
                        if (sourceItems[duplicateCheckField] == row) {
                            alert('Duplicate Entry Found');
                            valFound = true;
                        }
                        else {
                            valFound = false;
                        }
                    }
                    //break;
                }
                return valFound;
            };
            this.getDataSourceView = function (souceObj) {
                var viewRow = null;
                souceObj.fetch(function () {

                    viewRow = souceObj.view();
                })

                var gg = JSON.stringify(viewRow);
                if (viewRow.length == 0) return viewRow; else { return viewRow; }
            };
            this.getJSON = function () {
                var viewRow = null;
                souceObj.fetch(function () {

                    viewRow = souceObj.view();
                })

                if (viewRow.length == 0) {
                    var jsons = JSON.stringify(viewRow);
                    return jsons;
                }
                else {
                    var jsons = JSON.stringify(viewRow);
                    return jsons;
                }
            };
        },
    },

    // Get json from action url
    getPostAction: {
        getJSONString: function (controler, action, data, actionType) {

            function getJSONData(controler, action, data, callback) {
                callback();
            }

            getJSONData(controler, action, data, function () {

                $.ajax({
                    type: actionType
                    , url: "/" + controler + "/" + action
                    , data: JSON.stringify({ data: data })
                    , contentType: "application/json"
                    , success: function (data, result) {
                        return data;
                    },
                    error: function () {
                        //
                    }

                });
            });
        }
    },
    kendo: {
        dropDown: function (id, textField, valueField, listWidth, _template, _valueTemplate, filter, urlpath, _selectedIndex, _optionLabel, _isApproval, _isFilter, func) {
            this.dataSource = null;
            kendoDataSourceWithFilter(filter, urlpath, function (data) {
                //
                if (typeof this.dataSource == 'undefined') this.dataSource = new kendo.data.DataSource();
                kendoDropdownList(id, textField, valueField, data, listWidth, _template, _valueTemplate, _selectedIndex, _optionLabel, _isFilter);
                func(data);
            });

            function kendoDataSourceWithFilter(filter, urlpath, fn) {
                //
                if (this.dataSource == null) this.dataSource = new kendo.data.DataSource();
                if (this.dataSource._data.length == 0) {
                    appetizer.actionCall(urlpath, { 'IsApproval': _isApproval }, 'GET', function (data, result) {
                        // 
                        dataSource.data(data);
                        dataSource.filter(filter);
                        var filters = dataSource.filter();
                        var allData = dataSource.data();
                        var query = new kendo.data.Query(allData);
                        var data = query.filter(filters).data;
                        if (filter != null) fn(data); else fn(allData);
                    });
                }
                else {
                    //
                    dataSource.filter(filter);
                    var filters = dataSource.filter();
                    var allData = dataSource.data();
                    var query = new kendo.data.Query(allData);
                    var data = query.filter(filters).data;
                    if (filter != null) fn(data); else fn(allData);
                }
            }

            function kendoDropdownList(id, textField, valueField, source, listWidth, _template, _valueTemplate, _selectedIndex, _optionLabel, _isFilter) {
                //
                $("#" + id).kendoDropDownList({
                    dataTextField: textField,
                    dataValueField: valueField,
                    filter: _isFilter, //"contains"
                    dataSource: source,
                    valueTemplate: _valueTemplate,
                    template: _template,
                    optionLabel: _optionLabel,
                    index: _selectedIndex //,
                    //change: onChange
                });
                $("#" + id).data("kendoDropDownList").list.width(listWidth);
            }
        },
        kendoDropdownList: function (id, textField, valueField, listWidth, _template, _valueTemplate, urlpath, _selectedIndex, _optionLabel, _isApproval, _isFilter) {
            appetizer.actionCall(urlpath, { 'IsApproval': _isApproval }, 'GET', function (data, result) {
                //
                $("#" + id).kendoDropDownList({
                    dataTextField: textField,
                    dataValueField: valueField,
                    filter: _isFilter,  //"contains"
                    dataSource: data,
                    valueTemplate: _valueTemplate,
                    template: _template,
                    optionLabel: _optionLabel,
                    index: _selectedIndex
                    //change: onChange
                });
                $("#" + id).data("kendoDropDownList").list.width(listWidth);
            });
        }
    },
    // Test exmaple for new developers .. Hello World ... welcome to JS Literal
    test: {
        init: function (one, two) {
            this.one = one;
            this.two = two;
            this.getVal = function () {
                return this.one + this.two;
            }
        }
    },
    CheckPositveNumber: function (key) {
    try {
        var input = $('#' + key).val();
        // debugger;
        if (!/^(0?[1-9]\d*)$/.test(input)) {
            $('#' + key).val('');
            $('#e' + key).html('Enter a positive number');
            $('#e' + key).addClass('showError');
            $('#e' + key).removeClass('hideError');
            appetizer.message.showError('#showErrorMsg', 'Enter a positive number!', 10000);
            return;
        }
        var value = parseInt(input);
        if (isNaN(value) || value < 0) {
                
            $('#' + key).val('');
            $('#e' + key).html('Enter a positive number');
            $('#e' + key).addClass('showError');
            $('#e' + key).removeClass('hideError');
            appetizer.message.showError('#showErrorMsg', 'Enter a positive number!', 10000);
            return;
        }
        else {
            $('#e' + key).removeClass('showError');
            $('#e' + key).addClass('hideError');
        }
    }
    catch (err) {
        $('#e' + key).html('Enter a positive number');
        $('#e' + key).addClass('showError');
        $('#e' + key).removeClass('hideError');
        appetizer.message.showError('#showErrorMsg', 'Enter a positive number!', 10000);
    }

},

};

//Common function for control value exchanges ....lete des
function setControlsValue(jsonObj, nodeDiv, isCrear, isReset) {
    //;
    var isClearValue; var isResetValue;
    if (typeof (isCrear) === 'undefined') isClearValue = false; else isClearValue = isCrear;
    if (typeof (isReset) === 'undefined') isResetValue = false; else isResetValue = isReset;

    walk_the_DOM(nodeDiv, function (node) {
        //
        if (node.nodeType == 1) {
            //
            //do not remove
            //if (node.id == "ProductiveAssets") {
            //    //
            //}
            if ((node.localName == 'input' || node.localName == 'select' || node.type == 'textarea') && node.type != 'button') {
                if (isDateTimePicker(node) == 'k-widget k-datetimepicker k-header') {
                    //
                    var datepicker = $("#" + node.id).data("kendoDateTimePicker");
                    if (isResetValue != true) {
                        var dateValue = datepicker.value();
                        jsonObj.add(node.id, dateValue);
                    }
                    if (isResetValue == true) { isClearValue = true; }
                    if (isClearValue == true) {
                        var d = new Date();
                        var curr_date = d.getDate();
                        var curr_month = d.getMonth() + 1; //Months are zero based
                        var curr_year = d.getFullYear();
                        var curr_hour = d.getHours();
                        var curr_minute = d.getMinutes();

                        datepicker.value(new Date(curr_year, curr_month, curr_date, curr_hour, curr_minute));
                    }
                }
                else if (node.previousSibling != null) {

                    if (node.previousSibling.className == 'k-dropdown-wrap k-state-default' && node.id != "") {

                        var dropdownlist = $("#" + node.id).data("kendoDropDownList");
                        if (isResetValue != true) {
                            var ddlVal = dropdownlist.value();
                            var ddlTxt = dropdownlist.text();

                            var hasID = node.id.toLowerCase().search("id");
                            if (hasID != null) {
                                jsonObj.add(node.id, ddlVal);
                                //jsonObj.add(node.id.replace("ID", "Name"), ddlTxt); // only for grid relation binding ... need more discuss
                            }
                            else {
                                jsonObj.add(node.id.replace("Name", "ID"), ddlVal);
                                jsonObj.add(node.id, ddlTxt); // only for grid relation binding ... need more discuss
                            }
                        }
                        if (isResetValue == true) { isClearValue = true; }
                        if (isClearValue == true) dropdownlist.select(0);
                    }
                    else {
                        // 
                        if (node.previousSibling.className == 'k-formatted-value k-input') {
                            var numerictextbox = $('#' + node.id).data("kendoNumericTextBox");
                            if (isResetValue != true) {
                                var tagVal = numerictextbox.value();
                                jsonObj.add(node.id, tagVal);
                            }
                            if (isResetValue == true) { isClearValue = true; }
                            if (isClearValue == true) numerictextbox.value(0);
                        }
                        else {

                            if (node.id != "" && node.type == "checkbox") {
                                if (isResetValue != true) {
                                    jsonObj.add(node.id, node.checked);
                                }
                                if (isResetValue == true) { isClearValue = true; }
                                if (isClearValue == true) {
                                    if (node.type != 'hidden') { //clearing non hiden controls 
                                        $("#" + node.id).val('');
                                    }
                                }
                            }
                            if (node.id != "" && node.type == "select-multiple") {// Added By Belayet Using For Multy select box
                                
                                var multiSelect = $("#" + node.id).data("kendoMultiSelect");
                                if (isResetValue != true) {
                                    jsonObj.add(node.id, multiSelect.value());
                                }
                               
                            }
                            if (node.id != "" && node.type != "checkbox" && node.type != "select-multiple" && node.type == "radio") {
                                  //
                                  if (isResetValue != true && $("#" + node.id).is(':checked')) {
                                    jsonObj.add(node.name, node.value);
                                }
                               
                            }
                            if (node.id != "" && node.type != "checkbox" && node.type != "select-multiple" && node.type != "radio") {
                                //  
                                if (isResetValue != true) {
                                    jsonObj.add(node.id, node.value);
                                }
                                if (isResetValue == true) { isClearValue = true; }
                                if (isClearValue == true) {
                                    if (node.type != 'hidden') { //clearing non hiden controls 
                                        $("#" + node.id).val('');
                                    }
                                }
                            }
                            //;
                            if (node.id != "" && node.type == "file") {
                                if (isResetValue != true) {
                                    jsonObj.add(node.id, node.previousSibling.files[0].name);
                                }
                                if (isResetValue == true) { isClearValue = true; }
                                if (isClearValue == true) {
                                    if (node.type != 'hidden') { //clearing non hiden controls 
                                        $("#" + node.id).val('');
                                    }
                                }
                            }
                        }
                    }
                } // end of node.previousSibling
                else {
                    //
                    if (node.id != "") {
                        if (isResetValue != true) {
                            jsonObj.add(node.id, node.value);
                        }
                        if (isResetValue == true) { isClearValue = true; }
                        if (isClearValue == true) {
                            if (node.type != 'hidden') { //clearing non hiden controls 
                                $("#" + node.id).val('');
                            }
                        }
                    }
                }
            }
        }
    });
}
var walk_the_DOM = function walk(node, func) {
    func(node);
    node = node.firstChild;
    while (node) {
        walk(node, func);
        node = node.nextSibling;
    }
};

function isDateTimePicker(node) {
    var classNameKendoControl = "";
    if (node != null) {
        if (node.parentNode != null) {
            classNameKendoControl = node.parentNode.parentNode.className;
        }
    }
    return classNameKendoControl;
}

function OnKendoMultiSelectChange(e) {
    //
    var multuId = $(e.sender.element)[0].id;
    var current = this.value();
    var multiName = this.options.name;
    var previous = appetizer.multi.multiObjs[multuId];
    var diff = $(previous).not(current).get();
    appetizer.multi.delVals[multuId] = diff;
}

function OnKendoMultiSelectSelect(e) {
    // 
    var multuId = $(e.sender.element)[0].id;
    var newItem = [e.item.index()];
    appetizer.multi.addVals[multuId] = newItem;
}

function onRowBound(e) {
    //
    for (var i = 0; i < e.sender._data.length; i++) {
        if (e.sender._data[i]['modType'] == "D") {
            var currenRow = e.sender.table.find("tr[data-uid='" + e.sender._data[i]['uid'] + "']");
            currenRow.hide();
        }
    }
}

// Do not know why i written this, but i think this pugin is useful, so don't remove
//$.fn.serializeObject = function () {
//    var o = {};
//    var a = this.serializeArray();
//    $.each(a, function () {
//        if (o[this.name] !== undefined) {
//            if (!o[this.name].push) {
//                o[this.name] = [o[this.name]];
//            }
//            o[this.name].push(this.value || '');
//        } else {
//            o[this.name] = this.value || '';
//        }
//    });
//    return o;
//};

