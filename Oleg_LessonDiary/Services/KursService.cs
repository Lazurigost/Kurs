using Microsoft.EntityFrameworkCore;
using Oleg_LessonDiary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.Services
{
    public class KursService
    {
        private readonly NewlearnContext _newlearnContext;
        public KursService(NewlearnContext newlearnContext)
        {
            _newlearnContext = newlearnContext;
        }
        public async Task<List<Kur>> GetAllKursesAsync()
        {
            return await _newlearnContext.Kurs.ToListAsync();
        }
        public async Task<ObservableCollection<Lplan>> GetMyPlansAsync(Teacher user)
        {
            ObservableCollection<Lplan> lplans = new();
            List<Learnplan> plans = await _newlearnContext.Learnplans.ToListAsync();
            foreach( var pl in plans )
            {
                if (pl.LearnPlanIdTeacher == user.IdTeacher)
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

            }
            return lplans;
        }
        public async Task<int> GetPlanSubsAsync(Learnplan idplan)
        {
            List<Userssubscription> users = await _newlearnContext.Userssubscriptions.Where(u => u.UserssubscriptionIdPlan == idplan.IdLearnPlan).ToListAsync();

            return users.Count;

        }
        public async void AddNewKurs(Kur kurs)
        {
            Kur newKurs = new();
            if (kurs != null)
            {
                newKurs.IdKurs = _newlearnContext.Kurs.Max(u => u.IdKurs) + 1;
                newKurs.KursDuration = kurs.KursDuration;
                newKurs.KursStartDate = kurs.KursStartDate;
                newKurs.KursName = kurs.KursName;
                newKurs.KursIdGuitar = kurs.KursIdGuitar;
                await _newlearnContext.Kurs.AddAsync(newKurs);
                await _newlearnContext.SaveChangesAsync();
            }
        }
        public async void ChangeKurs(Kur kurs)
        {
            Kur newKurs = await _newlearnContext.Kurs.Where(k => k.IdKurs == kurs.IdKurs).FirstOrDefaultAsync();
            if(newKurs != null)
            {
                newKurs.KursDuration = kurs.KursDuration;
                newKurs.KursStartDate = kurs.KursStartDate;
                newKurs.KursName = kurs.KursName;
                newKurs.KursIdGuitar = kurs.KursIdGuitar;

                await _newlearnContext.SaveChangesAsync();
            }
            
        }
        public async void DeleteKurs(Kur kurs)
        {
            Kur? kur = await _newlearnContext.Kurs.Where(k => k.IdKurs == kurs.IdKurs).SingleOrDefaultAsync();

            if (kur != null)
            {
                _newlearnContext.Remove(kur);
                _newlearnContext.SaveChangesAsync();
            }
        }
    }
}
