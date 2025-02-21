import { Component, Output, EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Task } from '../../TaskModel';

@Component({
  selector: 'app-task-add',
  imports: [FormsModule],
  templateUrl: './task-add.component.html',
  styleUrl: './task-add.component.css'
})
export class TaskAddComponent {
  @Output() onAddTask = new EventEmitter<Task>();

  tarefa: string = "";
  categoria: string = "";
  concluido: boolean = false;
  showAddTask: boolean = false;

  onSubmit() {
    if (!this.tarefa) { alert("Verifique os dados e tente novamente"); return; }
    if (!this.categoria) { alert("Verifique os dados e tente novamente"); return; }

    const novaTarefa = {
      tarefa: this.tarefa,
      categoria: this.categoria,
      concluido: false
    }

    console.log(novaTarefa)
    this.onAddTask.emit(novaTarefa);

    this.tarefa = '';
    this.categoria = '';
    this.concluido = false;
  }

  toogleMenu() {
    this.showAddTask = !this.showAddTask;
  }

}
