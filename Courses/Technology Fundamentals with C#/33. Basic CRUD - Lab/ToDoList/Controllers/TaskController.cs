﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TaskController:Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (var db = new ToDoDbContext())
            {
                var allTasks = db.Tasks.ToList();
                return View(allTasks);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string title, string comments)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(comments))
            {
                return RedirectToAction("Index");
            }

            Task task = new Task
            {
                Title = title,
                Comments = comments
            };
            using (var db = new ToDoDbContext())
            {
                db.Tasks.Add(task);
                db.SaveChanges();
            }

                return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new ToDoDbContext())
            {
                var taskToEdit = db.Tasks.FirstOrDefault(t => t.Id == id);
                if (taskToEdit == null)
                {
                    return RedirectToAction("Index");
                }
                return this.View(taskToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Task task)
        { 
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }

            using (var db = new ToDoDbContext())
            {
                var taskToEdit = db.Tasks.FirstOrDefault(t => t.Id == task.Id);
                taskToEdit.Title = task.Title;
                taskToEdit.Comments = task.Comments;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            using (var db = new ToDoDbContext())
            {
                var taskToDetails = db.Tasks.FirstOrDefault(t => t.Id == id);
                if (taskToDetails == null)
                {
                    return RedirectToAction("Index");
                }
                return this.View(taskToDetails);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            using (var db = new ToDoDbContext())
            {
                var taskToDelete = db.Tasks.FirstOrDefault(t => t.Id == id);
                if (taskToDelete == null)
                {
                    return RedirectToAction("Index");
                }
                db.Tasks.Remove(taskToDelete);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
