export class Task {
    id?: number;
    taskName: string;
    taskStatus: boolean;
    taskFile: File;

    constructor() { }
}


export class TaskDetail {
    id: number;
    taskName: string;
    taskStatus: boolean;
    fileName: string;

    constructor() { }
}
