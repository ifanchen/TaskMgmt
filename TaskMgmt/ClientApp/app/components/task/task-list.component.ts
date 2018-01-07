import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { TaskDetail } from './task.model';
import { TaskService } from './task.service';
import { Inject } from '@angular/core';

@Component({
    selector: 'app-task-list',
    templateUrl: './task-list.component.html',
})
export class TaskListComponent {    
    tasks: TaskDetail[];
    filteredTasks: TaskDetail[];

    _showOpenTasks: boolean;

    get showOpenTasks(): boolean {
        return this._showOpenTasks;
    }
    set showOpenTasks(value: boolean) {
        this._showOpenTasks = value;
        this.filteredTasks = this._showOpenTasks ? this.getOpenTasks() : this.tasks;
    }

    constructor(private taskService: TaskService) {
        taskService.getTasks()
            .subscribe(result => {
                this.tasks = result;
                this.filteredTasks = result;
            }, error => console.error(error));
    }    

    getDownloadUrl(id: number): string {
        return this.taskService.getTaskAttachementLink(id);
    }

    closeTask(task: TaskDetail) {
        this.taskService.closeTask(task.id)
            .subscribe(result => {
                task.taskStatus = !task.taskStatus;
                this.filteredTasks = this._showOpenTasks ? this.getOpenTasks() : this.tasks;
            }, error => console.error(error));
    }

    getOpenTasks() : any {
        return this.tasks.filter((task: TaskDetail) => {
            return !task.taskStatus
        })
    }
}
