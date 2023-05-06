using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Лабораторная_работа___5.Models
{
    public class DatabaseModel
    {
        public int Id { get; set; }

        [DisplayName("Название базы данных")]
        public string Name { get; set; }

        [DisplayName("Дата создания")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Количество записей")]
        public int RecordsCount { get; set; }

        [DisplayName("Размер (в байтах)")]
        public long SizeInBytes { get; set; }

        [DisplayName("Автор")]
        public string Author { get; set; }
    }
}