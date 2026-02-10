using AutoEvidence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoEvidence.Services
{
    internal interface IStorageService
    {
        void SaveData(CarEvidenceData data);
        CarEvidenceData LoadData();
    }
}
