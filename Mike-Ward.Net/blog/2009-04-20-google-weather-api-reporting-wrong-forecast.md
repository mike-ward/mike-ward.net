Google Weather API reporting wrong forecast
2009-04-20T15:20:04
Google Weather API is reporting the current conditions but yesterday’s forecast. Hopefully the matter will be resolved shortly. Here’s an example of the data stream.
    
    <?xml version="1.0" ?> 
    - <xml_api_reply version="1">
    - <weather module_id="0" tab_id="0" mobile_row="0" mobile_zipped="1" row="0" section="0">
    - <forecast_information>
      <city data="Saline, MI" /> 
      <postal_code data="48176" /> 
      <latitude_e6 data="" /> 
      <longitude_e6 data="" /> 
      <forecast_date data="2009-04-19" /> 
      <current_date_time data="2009-04-20 14:46:02 +0000" /> 
      <unit_system data="US" /> 
      </forecast_information>
    - <current_conditions>
      <condition data="Light rain" /> 
      <temp_f data="54" /> 
      <temp_c data="12" /> 
      <humidity data="Humidity: 99%" /> 
      <icon data="/images/weather/mist.png" /> 
      <wind_condition data="Wind: SE at 2 mph" /> 
      </current_conditions>
    - <forecast_conditions>
      <day_of_week data="Sun" /> 
      <low data="43" /> 
      <high data="57" /> 
      <icon data="/images/weather/chance_of_rain.png" /> 
      <condition data="Chance of Showers" /> 
      </forecast_conditions>
    - <forecast_conditions>
      <day_of_week data="Mon" /> 
      <low data="37" /> 
      <high data="53" /> 
      <icon data="/images/weather/rain.png" /> 
      <condition data="Rain" /> 
      </forecast_conditions>
    - <forecast_conditions>
      <day_of_week data="Tue" /> 
      <low data="34" /> 
      <high data="47" /> 
      <icon data="/images/weather/rain.png" /> 
      <condition data="Showers" /> 
      </forecast_conditions>
    - <forecast_conditions>
      <day_of_week data="Wed" /> 
      <low data="34" /> 
      <high data="48" /> 
      <icon data="/images/weather/snow.png" /> 
      <condition data="Snow Showers" /> 
      </forecast_conditions>
      </weather>
      </xml_api_reply>

Notice that the forecast data is from 4/19/2009 but that the current conditions are 4/20/2009.
