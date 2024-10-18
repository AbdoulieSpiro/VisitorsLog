<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ControlPanelGray.ascx.cs"
    Inherits="HRSystemWeb.CustomControls_ControlPanelGray" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Src="~/CustomControls/AdministratorPortal.ascx" TagName="AdministratorPortal"
    TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<div class="floatright">
    <asp:Label ID="lblSiteName" runat="server" Font-Italic="true" ForeColor="Gray"></asp:Label>
</div>


<!-- ===============================================-->
<!--    Main Content-->
<!-- ===============================================-->



<main class="main" id="top">
    <div class="container" data-layout="container">
        <script>
            var isFluid = JSON.parse(localStorage.getItem('isFluid'));
            if (isFluid) {
                var container = document.querySelector('[data-layout]');
                container.classList.remove('container');
                container.classList.add('container-fluid');
            }
        </script>

        <script type="text/javascript">
            function triggerPostBack() {
                document.getElementById('<%= btnHidden.ClientID %>').click();
            }
        </script>

        <script type="text/javascript">
            function triggerPostBacks() {
                document.getElementById('<%= btntotTrans.ClientID %>').click();
            }
        </script>

        <div class="content">




            <div class="row g-3 mb-3" style="margin: 5px 0; padding-bottom: 20px;">
                <div class="card-header">
                    <div class="row flex-between-end">
                        <div class="col-auto align-self-center">
                            <h5 class="mb-0" data-anchor="data-anchor" style="color: royalblue !important;">Dashboard</h5>
                        </div>
                    </div>
                </div>

                <div class="col-md-4 col-lg-4">
                    <div class="row g-3 mb-3" style="">

                        <div class="col-md-12 col-lg-12">
                            <div class="card h-md-100 ecommerce-card-min-width" onclick="triggerPostBack()">
                                <div class="card-body d-flex flex-column justify-content-end bg-body-tertiary" style="padding-bottom: 10%">
                                    <div class="row">
                                        <div class="col">
                                            <h5 class="mb-0 mt-2 d-flex align-items-center" style="color: royalblue !important;">Total Daily Visits
                    <span class="ms-1 text-400" data-bs-toggle="tooltip" data-bs-placement="top" title="">
                        <span class="far fa-question-circle" data-fa-transform="shrink-1"></span>
                    </span>
                                            </h5>
                                            <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none;" />

                                            <asp:Label ID="lbltotal" Style="color: black; font-family: 'Lucida Sans Regular'; font-size: 15px; font-weight: bold;" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="col-md-4 col-lg-4">
                    <div class="row g-3 mb-3" style="">

                        <div class="col-md-12 col-lg-12">
                            <div class="card h-md-100 ecommerce-card-min-width" onclick="triggerPostBacks()">
                                <div class="card-body d-flex flex-column justify-content-end bg-body-tertiary" style="padding-bottom: 10%">
                                    <div class="row">

                                        <div class="col">
                                            <h5 class="mb-0 mt-2 d-flex align-items-center" style="color: royalblue !important;">Total Weekly Visits
                                                <span class="ms-1 text-400" data-bs-toggle="tooltip" data-bs-placement="top" title="">
                                                    <span class="far fa-question-circle" data-fa-transform="shrink-1"></span>
                                                </span>
                                            </h5>
                                            <asp:Button ID="btntotTrans" runat="server"  Style="display: none;" />

                                            <asp:Label ID="lbltotalTransaction" Style="color: black; font-family: 'Lucida Sans Regular'; font-size: 15px; font-weight: bold;" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="col-md-4 col-lg-4">
                    <div class="row g-3 mb-3" style="">

                        <div class="col-md-12 col-lg-12">
                            <div class="card h-md-100 ecommerce-card-min-width" onclick="">
                                <div class="card-body d-flex flex-column justify-content-end bg-body-tertiary" style="padding-bottom: 10%">
                                    <div class="row">
                                        <div class="col">
                                            <h5 class="mb-0 mt-2 d-flex align-items-center" style="color: royalblue !important;">Total Monthly Visits
     <span class="ms-1 text-400" data-bs-toggle="tooltip" data-bs-placement="top" title="">
         <span class="far fa-question-circle" data-fa-transform="shrink-1"></span>
     </span>
                                            </h5>
                                            <asp:Button ID="btnPendPurchase" runat="server" Style="display: none;" />

                                            <asp:Label ID="lblPendPurchase" Style="color: black; font-family: 'Lucida Sans Regular'; font-size: 15px; font-weight: bold;" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-8 col-lg-8" style="">
                    <asp:Panel ID="pnlCard" runat="server" CssClass="">





                        <div class="card h-auto " dir="ltr">
                            <div class="card-header">
                                <div class="row flex-between-end">
                                    <div class="col-auto align-self-center">
                                        <asp:Label CssClass="h2 form-label ss" Style="font-weight: bold" ID="Label2" runat="server" Text="Stock: "></asp:Label>

                                    </div>

                                </div>
                            </div>

                            <div class="card-body bg-body-tertiary">

                                <div class="echart-pie-chart-All" style="min-height: 270px;" data-echart-responsive="true"></div>

                            </div>
                        </div>
                    </asp:Panel>

                </div>




                <div class="col-lg-12 ps-lg-2 mb-3">
                    <div class="card h-lg-100">
                        <div class="card-header">
                            <div class="row flex-between-center">
                                <div class="col-auto">
                                    <h6 class="mb-0">
                                        <asp:Label ID="lblproduct" runat="server" />
                                        MONTHLY SALES
                                        <asp:Label ID="lblUOT" runat="server" /></h6>
                                </div>
<%--                                <div class="col-auto d-flex">
                                    <asp:DropDownList ID="drpItem" CssClass="form-select form-select-sm select-month me-2" runat="server" AutoPostBack="true" SkinID="aspPopupDropDown" Style="width: 200px; display: inline-block; margin-top: 4px;" OnSelectedIndexChanged="drpMonth_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-auto d-flex">
                                    <asp:DropDownList ID="drpLineDepot" CssClass="form-select form-select-sm select-month me-2" runat="server" AutoPostBack="true" SkinID="aspPopupDropDown" Style="width: 200px; display: inline-block; margin-top: 10px;" OnSelectedIndexChanged="drpLineDepot_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>--%>
                                <div class="col-auto d-flex">
                                    <asp:DropDownList ID="drpMonth" CssClass="form-select form-select-sm select-month me-2" runat="server" AutoPostBack="true" SkinID="aspPopupDropDown" Style="width: 200px; display: inline-block; margin-top: 10px;" OnSelectedIndexChanged="drpMonth_SelectedIndexChanged">

                                        <asp:ListItem Value="Jan">January</asp:ListItem>
                                        <asp:ListItem Value="Feb">February</asp:ListItem>
                                        <asp:ListItem Value="Mar">March</asp:ListItem>
                                        <asp:ListItem Value="Apr">April</asp:ListItem>
                                        <asp:ListItem Value="May">May</asp:ListItem>
                                        <asp:ListItem Value="Jun">June</asp:ListItem>
                                        <asp:ListItem Value="Jul">July</asp:ListItem>
                                        <asp:ListItem Value="Aug">August</asp:ListItem>
                                        <asp:ListItem Value="Sep">September</asp:ListItem>
                                        <asp:ListItem Value="9Oct">October</asp:ListItem>
                                        <asp:ListItem Value="Nov">November</asp:ListItem>
                                        <asp:ListItem Value="Dec">December</asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                            </div>
                        </div>
                        <div class="card-body h-100 pe-0">
                            <!-- Find the JS file for the following chart at: src\js\charts\echarts\total-sales.js-->
                            <!-- If you are not using gulp based workflow, you can find the transpiled code at: public\assets\js\theme.js-->
                            <%--<div class="echart-line-total h-100 " data-echart-responsive="true"></div>--%>
                            <div class="echart-line-total-sales h-100 " data-echart-responsive="true"></div>
                        </div>
                        <asp:Label ID="lblMessage" CssClass="form-label text-center" Font-Bold="true" ForeColor="Red" runat="server" Text=""> </asp:Label>

                    </div>
                </div>




               



            </div>
        </div>

    </div>
</main>



<script>
    function setChartData(data) {
        var $barTimelineChartEl = document.querySelector('.echart-bar-timeline-chart-Sales');
        if ($barTimelineChartEl) {
            var chart = echarts.init($barTimelineChartEl);

            var dataMap = {
                dataTI: {},
                dataSI: {},
                dataPI: {}
            };

            // Parse the received data to fit into the chart's dataMap
            data.forEach(function (item) {
                var year = new Date(item.CreatedOnDate).getFullYear();
                var month = new Date(item.CreatedOnDate).getMonth();

                if (!dataMap.dataTI[year]) {
                    dataMap.dataTI[year] = new Array(12).fill(0);
                    dataMap.dataSI[year] = new Array(12).fill(0);
                    dataMap.dataPI[year] = new Array(12).fill(0);
                }

                if (item.FromItem == 1) {
                    dataMap.dataTI[year][month] += item.FromAmount;
                } else if (item.FromItem == 2) {
                    dataMap.dataSI[year][month] += item.FromAmount;
                } else if (item.FromItem == 30071) {
                    dataMap.dataPI[year][month] += item.FromAmount;
                }
            });

            var getDefaultOptions = function () {
                var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
                return {
                    baseOption: {
                        timeline: {
                            axisType: 'category',
                            autoPlay: false,
                            playInterval: 1000,
                            data: Object.keys(dataMap.dataTI).map(function (year) {
                                return year + '-01-01';
                            }),
                            label: {
                                formatter: function (s) {
                                    return new Date(s).getFullYear();
                                }
                            },
                            lineStyle: { color: '#009688' },
                            itemStyle: { color: '#FF5722' },
                            checkpointStyle: {
                                color: '#4CAF50',
                                shadowBlur: 0,
                                shadowOffsetX: 0,
                                shadowOffsetY: 0
                            },
                            controlStyle: { color: '#009688' }
                        },
                        title: {
                            textStyle: { color: '#333' }
                        },
                        tooltip: {
                            trigger: 'axis',
                            axisPointer: { type: 'shadow' },
                            padding: [7, 10],
                            backgroundColor: '#fff',
                            borderColor: '#ccc',
                            textStyle: { color: '#333' },
                            borderWidth: 1,
                            transitionDuration: 0,
                            formatter: function (params) {
                                var tooltip = '';
                                params.forEach(function (param) {
                                    tooltip += param.marker + param.seriesName + ': ' + param.value + '<br>';
                                });
                                return tooltip;
                            }
                        },
                        legend: {
                            left: 'right',
                            data: ['Fertilizer', 'Rice', 'Vegetable Oil'],
                            textStyle: { color: '#333' }
                        },
                        calculable: true,
                        xAxis: [{
                            type: 'category',
                            data: months,
                            splitLine: { show: false },
                            axisLabel: { color: '#666' },
                            axisLine: { lineStyle: { color: '#ccc' } }
                        }],
                        yAxis: [{
                            type: 'value',
                            axisLabel: {
                                formatter: function (value) {
                                    return (value / 1000) + 'k';
                                },
                                color: '#666'
                            },
                            splitLine: { lineStyle: { color: '#eee' } }
                        }],
                        series: [{
                            name: 'Fertilizer',
                            type: 'bar',
                            itemStyle: {
                                color: '#FF5722',
                                barBorderRadius: [3, 3, 0, 0]
                            }
                        }, {
                            name: 'Rice',
                            type: 'bar',
                            itemStyle: {
                                color: '#009688',
                                barBorderRadius: [3, 3, 0, 0]
                            }
                        }, {
                            name: 'Vegetable Oil',
                            type: 'bar',
                            itemStyle: {
                                color: '#FFC107',
                                barBorderRadius: [3, 3, 0, 0]
                            }
                        }],
                        grid: {
                            top: '10%',
                            bottom: '15%',
                            left: 5,
                            right: 10,
                            containLabel: true
                        }
                    },
                    options: Object.keys(dataMap.dataTI).map(function (year) {
                        return {
                            title: { text: year },
                            series: [{
                                data: dataMap.dataPI[year]
                            }, {
                                data: dataMap.dataSI[year]
                            }, {
                                data: dataMap.dataTI[year]
                            }]
                        };
                    })
                };
            };

            var options = getDefaultOptions();
            chart.setOption(options);
        }
    }




</script>
