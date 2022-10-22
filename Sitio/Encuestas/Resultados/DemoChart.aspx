<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DemoChart.aspx.cs" Inherits="Encuestas_Resultados_DemoChart" %>

<!doctype html>
<html>
<head>
    <title>Basic usage bar chart</title>
    <link href="../../App_Themes/PulseTheme/css/kendo/examples.css" rel="stylesheet" />
    <link href="../../App_Themes/PulseTheme/css/kendo/examples-offline.css" rel="stylesheet" />
    <link href="../../App_Themes/PulseTheme/css/kendo/styles/kendo.common.min.css" rel="stylesheet" />
    <link href="../../App_Themes/PulseTheme/css/kendo/styles/kendo.default.min.css" rel="stylesheet" />

    <script src="../../scripts/jquery-1.6.4.min.js"></script>

    <script src="../../scripts/kendo/kendo.core.min.js"></script>

    <script src="../../scripts/kendo/kendo.data.min.js"></script>

    <script src="../../scripts/kendo/kendo.chart.min.js"></script>

</head>
<body>
    <a href="../index.html">Back</a>
    <div class="description">
        Basic usage</div>
    <div id="example" class="k-content">
        <div class="chart-wrapper">
            <div id="chart">
            </div>
        </div>

        <script>
            function createChart() {
                $("#chart").kendoChart({
                    theme: $(document).data("kendoSkin") || "default",
                    title: {
                        text: "Break-up of Spain Electricity Production for 2008"
                    },
                    legend: {
                        position: "bottom"
                    },
                    seriesDefaults: {
                        labels: {
                            visible: true,
                            format: "{0}%"
                        }
                    },
                    series: [{
                        type: "pie",
                        data: [{ category: "Hydro", value: 22 }, { category: "Solar", value: 2 }, { category: "Nuclear", value: 49 }, { category: "Wind", value: 27}]}],
                        tooltip: { 
                            visible: true,
                            format: "{0}%"
                        }
                    });
                }

                $(document).ready(function() {
                    setTimeout(function() {
                        createChart();
                    }, 400);

                    $(document).bind("kendo:skinChange", function(e) {
                        createChart();
                    });
                });
            </script>

    </div>
</body>
</html>
