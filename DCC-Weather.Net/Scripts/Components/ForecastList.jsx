var React = require('react');

var ForecastList = React.createClass({
    getForecast: function () {
        var days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];

        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            data.forEach(function (forecast) {
                forecast.ForecastDate = days[eval("new " + forecast.ForecastDate.slice(1, -1)).getDay()];
            })
            this.setState({
                data: data,
                isLoading: false
            });
        }.bind(this);
        xhr.send();
    },
    getInitialState: function () {
        return {
            data: [],
            isLoading: true
        };
    },
    componentWillMount: function () {
        this.getForecast();
    },
    render: function () {
        var forecastNodes = this.state.data.map(function (forecastItem) {
            return (
                <ForecastItem data={forecastItem} />
            )
        })
        return (
            <div className={"forecastList row"}>
                {this.state.isLoading === true ? <LoadingIcon /> : false }
                {forecastNodes}
            </div>
        );
    }
});

var ForecastTitle = React.createClass({
    render: function () {
        return (
            <div className={"row"}>
                <div className={"col-xs-8 col-sm-6 col-md-6"}>
                    <span className={"forecast-day"}>{this.props.ForecastDate}</span>
                </div>
                <div className={"forecast-icon col-xs-4 col-sm-4 col-sm-offset-2 col-md-4 col-md-offset-2"}>
                    <img src={this.props.IconUrl} />
                </div>
            </div>
            )        
    }
});

var ForecastConditions = React.createClass({
    render: function () {
        return (
            <span className={"forecast-conditions"}>{this.props.Conditions}</span>
            )
    }
});

var ForecastTemperature = React.createClass({
    render: function () {
        return (
            <div className={"row" }>
                <div className={"col-xs-8"}></div>
                <div className={"forecast-temp-div col-xs-4 col-sm-4 col-sm-offset-8 col-md-6 col-md-offset-6" }>
                    <span className={"forecast-temp" }>{this.props.temp}&deg;</span>
                    {this.props.diff > 0 ? <span className={"forecast-temp-diff" }>+{this.props.diff}</span> : false}
                    {this.props.diff < 0 ? <span className={"forecast-temp-diff" }>{this.props.diff}</span> : false}
                </div>
            </div>
            )
    }
});

var ForecastItem = React.createClass({    
    render: function () {
        return (
            <div className={"col-md-3 col-sm-6 col-xs-12"}>
                <div className={"panel panel-default"}>
                <div className={"forecast-panel-body panel-body"}>
                    <div className={"forecast-item"}>
                        <ForecastTitle ForecastDate={this.props.data.ForecastDate} IconUrl={this.props.data.IconUrl}/>
                        <ForecastConditions Conditions={this.props.data.Conditions}/>
                        <ForecastTemperature temp={this.props.data.High} diff={this.props.data.HighDiff}/>
                        <ForecastTemperature temp={this.props.data.Low} diff={this.props.data.LowDiff}/>
                    </div>
                </div>
                </div>
            </div>
        )
}
});

var LoadingIcon = React.createClass({
    render: function () {
        return (
               <div className={"col-xs-6 col-sm-6 col-md-6 col-xs-offset-3 col-sm-offset-3 col-md-offset-3 text-center"}>
                   <span className={"glyphicon glyphicon-cloud loading-icon"}>&nbsp;</span>
                   <br />
                   <span className={"loading-text" }>Checking the weather...</span>
               </div>
        )
}
})

module.exports = ForecastList;

ReactDOM.render(
    <ForecastList url="/threedayforecast" />,
    document.getElementById('content')
);
