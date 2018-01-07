import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { NgForm, FormGroup, FormControl, Validators } from '@angular/forms';
import { Task } from './task.model';
import { TaskService } from './task.service';
import { Http } from '@angular/http';
import { Router } from '@angular/router';

@Component({
    selector: 'app-task-edit',
    templateUrl: './task-edit.component.html',
})
export class TaskEditComponent implements OnInit {        
    task: Task = new Task();
    taskForm: FormGroup;
    updatedTask: Task = new Task();    
    @ViewChild("uploader") uploader: any;

    constructor(private http: Http,
        @Inject('BASE_URL') private baseUrl: string,
        private taskService: TaskService,
        private router: Router) {        
    }

    ngOnInit(): void {
        this.taskForm = new FormGroup({            
            'taskName': new FormControl(null, [Validators.required]),
            'taskFile': new FormControl(null)
        });
    }
    
    fileChange(files: FileList) {
        if (files && files[0].size > 0) {
            this.task.taskFile = files[0];
            //Todo: Currently only allow to upload files smaller than 23MB
            if (files[0].size < 23000000) {
                this.taskForm.patchValue({
                    'taskFile': files[0]
                });
            }            
        }
    }

    getFormData(): FormData {
        const formModel = this.taskForm.value;

        let formData = new FormData();
        formData.append("taskName", formModel.taskName);
        formData.append("taskFile", formModel.taskFile);

        return formData;
    }

    onSubmit() {
        
        console.log(this.getFormData());
        
        this.taskService.createTask(this.getFormData())
            .subscribe(result => {        
                console.log(result);
                this.router.navigate(['/tasks']);
            }, error => console.error(error));     

/*
        
        this.http.post(this.baseUrl + 'api/Tasks', this.getFormData())
            .subscribe(result => {
                //this.updatedTask = result.json() as Task;
                console.log(result);
                this.router.navigate(['/tasks']);
            }, error => console.error(error));        
            */
    }
}
