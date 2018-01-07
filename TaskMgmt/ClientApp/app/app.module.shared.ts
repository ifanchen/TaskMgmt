import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { HomeComponent } from './components/home/home.component';
import { TaskEditComponent } from './components/task/task-edit.component';
import { TaskService } from './components/task/task.service';
import { TaskListComponent } from './components/task/task-list.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
    declarations: [
        AppComponent,        
        TaskEditComponent,
        TaskListComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },            
            { path: 'edit', component: TaskEditComponent },
            { path: 'tasks', component: TaskListComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [TaskService]
})
export class AppModuleShared {
}
