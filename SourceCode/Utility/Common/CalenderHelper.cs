using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility//DataLayer.Common
{
   public static class CalenderHelper
    {


        public static List<CalenderChart> GetWeeks_OfMonth(DateTime _date)
        {
            try
            {

                int TotalDaysInAMonth = DateTime.DaysInMonth(_date.Year, _date.Month);
                DateTime Defaultdt = new DateTime(0001, 01, 01);
                List<CalenderChart> VisitList = new List<CalenderChart>();
                CalenderChart visit;
                for (int count = 1; count <= TotalDaysInAMonth; count++)
                {
                    visit = new CalenderChart();
                    DateTime dt = new DateTime(_date.Year, _date.Month, count);

                    if (count == 1)
                        visit.WeekStartDate = dt;

                    if (count == TotalDaysInAMonth)
                        visit.WeekEndDate = dt;

                    if (dt.DayOfWeek == DayOfWeek.Sunday)
                    {
                        var CheckExist = (from st in VisitList
                                          where st.WeekStartDate == dt
                                          select st.WeekStartDate).LastOrDefault();

                        if (CheckExist == null)
                            visit.WeekStartDate = dt;

                    }

                    if (dt.DayOfWeek == DayOfWeek.Saturday)
                    {
                        var CheckExistt = (from end in VisitList
                                           where end.WeekEndDate == dt
                                           select end.WeekEndDate).LastOrDefault();

                        if (CheckExistt == null)
                            visit.WeekEndDate = dt;
                    }


                    VisitList.Add(visit);

                }


                var StartWeeks = (from vs in VisitList
                                  where vs.WeekStartDate != null
                                  select vs.WeekStartDate).ToList();

                var EndWeeks = (from vs in VisitList
                                where vs.WeekEndDate != null
                                select vs.WeekEndDate).ToList();

                VisitList = new List<CalenderChart>();
                for (int count = 0; count < StartWeeks.Count; count++)
                {
                    visit = new CalenderChart();
                    visit.WeekStartDate = StartWeeks[count].Value.Date;
                    visit.WeekEndDate = EndWeeks[count].Value.Date;
                    visit.Week = "Week-" + (count + 1);
                    visit.Day = StartWeeks[count].Value.DayOfWeek.ToString() + " To " + EndWeeks[count].Value.DayOfWeek.ToString();
                    VisitList.Add(visit);
                }

                return VisitList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<DateTime> GetDates_OfWeek(DateTime dt)
        {
            List<DateTime> Dates = new List<DateTime>();
            try
            {
                //DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                //DateTime dt = new DateTime(2016, 02, 29);
                DateTime Defaultdt = new DateTime(0001, 01, 01);
                int Day = dt.Day;

                
                DateTime chk = dt;
                while (chk.DayOfWeek != DayOfWeek.Sunday)
                {
                    Day--;
                    if (Day > 0)
                    {
                        chk = new DateTime(chk.Year, chk.Month, Day);
                        Dates.Add(chk);
                    }
                    else
                        break;
                }
                Day = dt.Day;
                chk = dt;
                while (chk.DayOfWeek != DayOfWeek.Saturday)
                {

                    if ((DateTime.DaysInMonth(dt.Date.Year, dt.Date.Month)) >= Day)
                    {
                        chk = new DateTime(chk.Year, chk.Month, Day);
                        Dates.Add(chk);
                    }
                    else
                        break;
                    Day++;
                }
                chk = dt;


                Dates = (from dts in Dates
                         orderby dts.Date
                         select dts).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Dates;

        }
    }
   public  class CalenderChart
   {
       public DateTime? WeekStartDate;
       public DateTime? WeekEndDate;
       public string Day;
       public string Week;
   }
}
