﻿using ChartJs.Blazor.ChartJS.BarChart.Dataset;
using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.LineChart;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.MixedChart
{
    [JsonConverter(typeof(MixableDatasetConverter))]
    public interface IMixableDataset<out TData>
    {
        ChartTypes Type { get; }
        IReadOnlyCollection<TData> Data { get; }
    }

    public class MixableDatasetConverter : JsonConverter
    {
        public override bool CanRead => true;
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IMixableDataset<>);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Don't use me to write JSON");
        }

        public override object ReadJson(JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            JObject jObj = JObject.Load(reader);
            ChartTypes type = jObj.Value<ChartTypes>("Type") ?? jObj.Value<ChartTypes>("type");

            IMixableDataset<object> dataset = null;
            switch ((string)type)
            {
                case "bar":
                {
                    dataset = new BarChartDataset<object>();
                    break;
                }

                case "line":
                {
                    dataset = new LineChartDataset<object>();
                    break;
                }
            }

            serializer.Populate(jObj.CreateReader(), dataset);

            return dataset;
        }
    }
}