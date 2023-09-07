using Oleg_LessonDiary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public async Task<ObservableCollection<Lplan>> GetAllPlansAsync()
        {
            List<Learnplan> plans = await _context.Learnplans.ToListAsync();
            ObservableCollection<Lplan> lplans = new();
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
        public async Task<ObservableCollection<Lplan>> GetUserPlan(UserModel user)
        {
            List<Userssubscription> subs = await _context.Userssubscriptions.Where(s => s.UserssubsriptionIdUsers == user.IdUsers).ToListAsync();
            List<Learnplan> plans = await _context.Learnplans.ToListAsync();
            ObservableCollection<Lplan> lplans = new();

            foreach (var pl in plans)
            {
                var plan = subs.FirstOrDefault(g => g.UserssubscriptionIdPlan == pl.IdLearnPlan);
                if (plan == null)
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
                };
            }
            return lplans;
        }
        public async Task<int> GetPlanSubsAsync(Learnplan idplan)
        {
            List<Userssubscription> users = await _context.Userssubscriptions.Where(u => u.UserssubscriptionIdPlan == idplan.IdLearnPlan).ToListAsync();

            return users.Count;

        }
        public async Task<ObservableCollection<Lplan>> GetAllSubs(UserModel user)
        {
            List<Userssubscription> subs = await _context.Userssubscriptions.Where(s => s.UserssubsriptionIdUsers == user.IdUsers).ToListAsync();
            List<Learnplan> plans = await _context.Learnplans.ToListAsync();
            ObservableCollection<Lplan> lplans = new();

            foreach (var pl in plans)
            {
                var plan = subs.FirstOrDefault(g => g.UserssubscriptionIdPlan == pl.IdLearnPlan);
                if (plan != null)
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
                };
            }
            return lplans;
        }
        public async void DeletePlan(Lplan plan)
        {
            Learnplan lplan = await _context.Learnplans.Where(p => p.IdLearnPlan ==  plan.IdLearnPlan).FirstOrDefaultAsync();
            if (lplan != null)
            {
                _context.Learnplans.Remove(lplan);
                _context.SaveChanges();
            }
        }
        public async Task<List<User>> GetSubbedUsersAsync(int id)
        {
            Learnplan plan = await _context.Learnplans.Where(p => p.IdLearnPlan == id).FirstOrDefaultAsync();
            List<Userssubscription> subs = await _context.Userssubscriptions.Where(s => s.UserssubscriptionIdPlan == id).ToListAsync();
            List<User> users = new();
            foreach (var sub in subs)
            {
                if (users.Contains(sub.UserssubsriptionIdUsersNavigation.IdLearningUsersNavigation))
                {
                    
                }
                else
                {
                    users.Add(sub.UserssubsriptionIdUsersNavigation.IdLearningUsersNavigation);
                }
            }
            return users;
        }
        public async void CreateLearnplan(Kur kurs)
        {
            Learnplan newPlan = new();
            newPlan.LearnPlanIdTeacher = Global.teacher.IdTeacher;
            newPlan.LearnPlanIdKurs = kurs.IdKurs;
            newPlan.LearnPlanRestriction = 10;

            _context.AddAsync(newPlan);
            _context.SaveChanges();
        }
    }
}
