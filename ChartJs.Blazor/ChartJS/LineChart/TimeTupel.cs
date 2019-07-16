﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    /// <summary>
    /// Represents a point on a graph where the X-Value (<see cref="Time"></see>) is represented by a <see cref="Moment"></see>
    /// <para>Should be used together with a <see cref="TimeAxis"></see></para>
    /// <para>Reference Type so it can be used in the covariant <see cref="MixedChart.IMixableDataset{TData}"/></para>
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class TimeTupel<TData>
    {
        public TimeTupel(Moment time, TData yValue)
        {
            Time = time;
            YValue = yValue;
        }

        [JsonProperty("t")]
        public Moment Time { get; set; }

        [JsonProperty("y")]
        public TData YValue { get; set; }
    }
}