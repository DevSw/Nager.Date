﻿using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Isle of Man
    /// https://en.wikipedia.org/wiki/Public_holidays_in_the_Isle_of_Man
    /// </summary>
    public class IsleOfManProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// IsleOfManProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public IsleOfManProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.IM;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var firstMondayInMay = DateSystem.FindDay(year, 5, DayOfWeek.Monday, 1);
            var lastMondayInMay = DateSystem.FindLastDay(year, 5, DayOfWeek.Monday);
            var secondFridayInJune = DateSystem.FindDay(year, 6, DayOfWeek.Friday, 2);
            var lastMondayInAugust = DateSystem.FindLastDay(year, 8, DayOfWeek.Monday);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(firstMondayInMay, "Labour Day", "Labour Day", countryCode));
            items.Add(new PublicHoliday(lastMondayInMay, "Spring Bank Holiday", "Spring Bank Holiday", countryCode));
            items.Add(new PublicHoliday(secondFridayInJune, "Senior Race Day", "Senior Race Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 5, "Tynwald Day", "Tynwald Day", countryCode));
            items.Add(new PublicHoliday(lastMondayInAugust, "Late Summer Bank Holiday", "Late Summer Bank Holiday", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
