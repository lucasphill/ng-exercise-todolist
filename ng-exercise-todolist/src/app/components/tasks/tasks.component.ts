import { Component, OnInit } from '@angular/core';
import { TaskService } from '../../services/task.service';
import { Task } from '../../TaskModel';
import { TaskItemComponent } from '../task-item/task-item.component';
import { TaskAddComponent } from '../task-add/task-add.component';

@Component({
  selector: 'app-tasks',
  imports: [TaskItemComponent, TaskAddComponent],
  templateUrl: './tasks.component.html',
  styleUrl: './tasks.component.css'
})
export class TasksComponent implements OnInit {

  tasks: Task[] = []

  constructor(private taskService: TaskService) { }

  ngOnInit(): void {
    this.updateList();
  }

  updateList() {
    this.taskService.getTasks().subscribe((data) => {
      this.tasks = data
      // console.log(data)
    });
  }

  deleteTask(task: Task) { //verificar isso aqui
    this.taskService.deleteTask(task).subscribe(() => (this.tasks = this.tasks.filter((t) => t.id !== task.id))); //subscribe pega as informações da tarefa executada e faz alguma coisa ou não
  }

  toggleFinish(task: Task) {
    task.concluido = !task.concluido;
    this.taskService.updateTask(task).subscribe()
  }

  addTask(task: Task) {
    this.taskService.addTask(task).subscribe(() => {
      this.updateList();
    });

  }

}
