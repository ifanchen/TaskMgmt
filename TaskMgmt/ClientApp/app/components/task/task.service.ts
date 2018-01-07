import { Injectable, Inject } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Task, TaskDetail } from './task.model';
import 'rxjs/add/operator/map';

@Injectable()
export class TaskService {
    
    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }


    getTasks(): Observable<TaskDetail[]> {
        return this.http.get(this.baseUrl + 'api/Tasks')
            .map(response => response.json());
    }

    getTaskAttachementLink(id: number): string {
        return `${this.baseUrl}api/tasks/download/${id}`;
    }

    createTask(formData: FormData): Observable<Response> {        
        return this.http.post(this.baseUrl + 'api/Tasks', formData);
    }

    closeTask(id: number): Observable<Response> {
        return this.http.get(this.baseUrl + 'api/Tasks/Close/' + id);
    }

}
