using Catrobat.Common;
using Catrobat.Models;
using Catrobat.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace Catrobat.Repositories
{
    class CatrobatProgramRepository : IRepository<CatrobatProgram>
    {
        private string _destPath = string.Format("{0}\\Projects", Windows.Storage.ApplicationData.Current.LocalFolder.Path);
        private ExtractService _extractService;

        public CatrobatProgramRepository(ExtractService extractService)
        {
            _extractService = extractService;
        }

        public CatrobatProgram Add(CatrobatProgram item)
        {
            throw new NotImplementedException();
        }

        public void Delete(CatrobatProgram item)
        {
            throw new NotImplementedException();
        }

        public CatrobatProgram Get(string id)
        {
            _extractService.ExtractPrograms();
            string storagePath = string.Format("{0}\\{1}", Constants.PROJECT_PATH, id);
            if (Directory.Exists(storagePath))
                return new CatrobatProgram(storagePath);
            else
                return null;
        }

        public IList<CatrobatProgram> GetAll()
        {
            _extractService.ExtractPrograms();
            List<CatrobatProgram> programs = new List<CatrobatProgram>();
            foreach (string storagePath in Directory.GetDirectories(Constants.PROJECT_PATH))
            {
                programs.Add(new CatrobatProgram(storagePath));
            }
            return programs;
        }

        public CatrobatProgram Update(CatrobatProgram item)
        {
            throw new NotImplementedException();
        }

    }
}
