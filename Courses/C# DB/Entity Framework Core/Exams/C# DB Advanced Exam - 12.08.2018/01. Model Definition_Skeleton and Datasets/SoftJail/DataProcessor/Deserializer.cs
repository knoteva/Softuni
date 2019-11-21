namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentsDto = JsonConvert.DeserializeObject<ImportDepartmentsCellsDto[]>(jsonString);
            var sb = new StringBuilder();
            var departments = new List<Department>();

            foreach (var departmentDto in departmentsDto)
            {
                if (!IsValid(departmentDto) || departmentDto.Cells.Any(c => IsValid(c) == false))
                {
                    sb.AppendLine($"Invalid Data");
                    continue;
                }

                var department = new Department
                {
                    Name = departmentDto.Name,
                };


                foreach (var currentCell in departmentDto.Cells)
                {
                    department.Cells.Add(new Cell
                    {
                        CellNumber = currentCell.CellNumber,
                        HasWindow = currentCell.HasWindow
                    });
                }

                departments.Add(department);
                sb.AppendLine($"Imported {departmentDto.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return "";
            //sb.ToString().TrimEnd();
        }



        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersDto = JsonConvert.DeserializeObject<ImportPrisonersMailsDto[]>(jsonString);
            var sb = new StringBuilder();
            var prisoners = new List<Prisoner>();

            foreach (var prisonerDto in prisonersDto)
            {
                if (!IsValid(prisonerDto) || prisonerDto.Mails.Any(c => IsValid(c) == false))
                {
                    sb.AppendLine($"Invalid Data");
                    continue;
                }
                var prisoner = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = DateTime.ParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ReleaseDate = prisonerDto.ReleaseDate == null ? (DateTime?)null : DateTime.ParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    //ReleaseDate = string.IsNullOrEmpty(prisonerDto.ReleaseDate) ? (DateTime?)null : DateTime.ParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId
                };

                foreach (var currentMail in prisonerDto.Mails)
                {
                    prisoner.Mails.Add(new Mail
                    {
                        Description = currentMail.Description,
                        Sender = currentMail.Sender,
                        Address = currentMail.Address
                    });
                }

                prisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisonerDto.FullName} {prisonerDto.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return "";
            //sb.ToString().TrimEnd();
        }



        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportOfficersPrisonersDto[]), new XmlRootAttribute("Officers"));
            var officersDto = (ImportOfficersPrisonersDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var officers = new List<Officer>();

            foreach (var officerDto in officersDto)
            {
                if (!IsValid(officerDto))
                {
                    sb.AppendLine($"Invalid Data");
                    continue;
                }

                var isValidEnumPosition = Enum.TryParse<Position>(officerDto.Position, out Position positionType);
                var isValidEnumnWeapon = Enum.TryParse<Weapon>(officerDto.Weapon, out Weapon weaponType);

                if (!isValidEnumPosition || !isValidEnumnWeapon)
                {
                    sb.AppendLine($"Invalid Data");
                    continue;
                }


                var officer = new Officer
                {
                   FullName = officerDto.Name,
                   Salary = officerDto.Money,
                   Position = positionType,
                   Weapon = weaponType,
                   DepartmentId = officerDto.DepartmentId
                };

                foreach (var currentprisoner in officerDto.Prisoners)
                {
                    officer.OfficerPrisoners.Add(new OfficerPrisoner
                    {
                        PrisonerId = currentprisoner.Id
                    });
                }
                officers.Add(officer);
                sb.AppendLine($"Imported {officerDto.Name} ({officerDto.Prisoners.Length} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();
            return "";
            //sb.ToString().TrimEnd();

        }



        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);
            return isValid;
        }
    }
}