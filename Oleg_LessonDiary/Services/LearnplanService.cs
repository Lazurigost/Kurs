﻿using Oleg_LessonDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.Services
{
    public class LearnplanService
    {
        private readonly NewlearnContext _context;

        public LearnplanService(NewlearnContext context)
        {
            _context = context;
        }
        public async Task<List<Lplan>> GetAllPlansAsync()
        {
            List<Learnplan> plans = await _context.Learnplans.ToListAsync();
            List<Lplan> lplans = new();
            foreach (var pl in plans)
            {
                lplans.Add(new Lplan
                {
                    IdLearnPlan = pl.IdLearnPlan,
                    LearnPlanIdKurs = pl.LearnPlanIdKurs,
                    LearnPlanIdKursNavigation = pl.LearnPlanIdKursNavigation,
                    LearnPlanIdTeacher = pl.LearnPlanIdTeacher,
                    LearnPlanIdTeacherNavigation = pl.LearnPlanIdTeacherNavigation,
                    LearnPlanRestriction = pl.LearnPlanRestriction,
                    Subcount = await GetPlanSubsAsync(pl)

                });
            }
            return lplans;
        }
        public async Task<int> GetPlanSubsAsync(Learnplan idplan)
        {
            List<Userssubscription> users = await _context.Userssubscriptions.Where(u => u.UserssubscriptionIdPlan == idplan.IdLearnPlan).ToListAsync();

            return users.Count;
        }
    }
}
