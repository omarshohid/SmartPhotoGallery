
var GraphManager = {
     
    loadChartInfo: function (ctrlName,chartType, title, data, lstCategory) {
        
        $("#" + ctrlName).kendoChart({
            theme: "flat",
                title: {
                    text: title
                },
                legend: {
                    position: "top"
                },
                seriesDefaults: {
                    type: chartType
                },
                series: data,
                valueAxis: {
                    labels: {
                        format: "{0}%"
                    },
                    line: {
                        visible: false
                    },
                    axisCrossingValue: 0
                },
                categoryAxis: {
                    categories: lstCategory,
                    line: {
                        visible: false
                    },
                    labels: {
                        padding: { top: 135 }
                    }
                },
                tooltip: {
                    visible: true,
                    format: "{0}%",
                    template: "#= series.name #: #= value #"
                }
            });
    },
    loadPieChart: function (ctrlName, title, data) {
        $("#" + ctrlName).kendoChart({
            theme:"flat",
                title: {
                    position: "bottom",
                    text: title
                },
                legend: {
                    visible: false
                },
                chartArea: {
                    background: ""
                },
                seriesDefaults: {
                    labels: {
                        visible: true,
                        background: "transparent",
                        template: "#= category #: \n #= value#%"
                    }
                },
                series: [{
                    type: "pie",
                    startAngle: 150,
                    data: data
                }],
                tooltip: {
                    visible: true,
                    format: "{0}%"
                }
            });
    },
    
}



//function createChart() {
//    $("#chart").kendoChart({
//        title: {
//            text: "Tracking Summery List"
//        },
//        legend: {
//            position: "top"
//        },
//        seriesDefaults: {
//            type: "column"
//        },
//        series: [{
//            name: "ANC PNC",
//            data: [3.907, 7.943, 7.848, 9.284, 9.263, 9.801, 3.890, 8.238, 9.552, 6.855]
//        }, {
//            name: "Training",
//            data: [4.743, 7.295, 7.175, 6.376, 8.153, 8.535, 5.247, 5.832, 4.3, 4.3]
//        }, {
//            name: "IGA Usess",
//            data: [0.010, -0.375, 1.161, 0.684, 3.7, 3.269, 1.083, 4.127, 3.690, 2.995]
//        }, {
//            name: "Input IGA",
//            data: [1.988, 2.733, 3.994, 3.464, 4.001, 3.939, 1.333, 3.245, 4.339, 2.727]
//        }],
//        valueAxis: {
//            labels: {
//                format: "{0}%"
//            },
//            line: {
//                visible: false
//            },
//            axisCrossingValue: 0
//        },
//        categoryAxis: {
//            categories: [2002, 2003, 2004, 2005, 2006, 2007, 2008, 2009, 2010, 2011],
//            line: {
//                visible: false
//            },
//            labels: {
//                padding: { top: 135 }
//            }
//        },
//        tooltip: {
//            visible: true,
//            format: "{0}%",
//            template: "#= series.name #: #= value #"
//        }
//    });
//}