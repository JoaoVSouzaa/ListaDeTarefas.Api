import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

interface Tarefa {
  id: string;
  titulo: string;
  descricao: string;
  status: number;
  dataCriacao: string;
  dataAtualizacao: string | null;
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
})
export class AppComponent implements OnInit {
  tarefas: Tarefa[] = [];

  novaTarefa = {
    titulo: '',
    descricao: '',
    status: 1
  };

  editandoId: string | null = null;
  filtroStatus: number | null = null;
  carregando = false;
  mensagem = '';

  constructor(
    private http: HttpClient,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.buscarTarefas();
  }

  buscarTarefas() {
    this.carregando = true;
    this.cdr.detectChanges();

    const url = this.filtroStatus
      ? `http://localhost:5007/api/Tarefas/status?status=${this.filtroStatus}`
      : 'http://localhost:5007/api/Tarefas';

    this.http.get<Tarefa[]>(url)
      .subscribe({
        next: (res) => {
          this.tarefas = res;
        },
        error: (err) => {
          console.error('Erro ao buscar tarefas:', err);
        },
        complete: () => {
          this.carregando = false;
          this.cdr.detectChanges();
        }
      });
  }

  criarTarefa() {
    const payload = {
      titulo: this.novaTarefa.titulo,
      descricao: this.novaTarefa.descricao
    };

    this.http.post('http://localhost:5007/api/Tarefas', payload)
      .subscribe({
        next: () => {
          this.buscarTarefas();
          this.limparFormulario();

          this.mensagem = 'Tarefa criada com sucesso!';
          setTimeout(() => this.mensagem = '', 3000);
        },
        error: (err) => {
          console.error('Erro ao criar tarefa:', err);
        }
      });
  }

  atualizarTarefa() {
    if (!this.editandoId) {
      return;
    }

    const tarefaAtualizada = {
      titulo: this.novaTarefa.titulo,
      descricao: this.novaTarefa.descricao,
      status: this.novaTarefa.status
    };

    this.http.put(`http://localhost:5007/api/Tarefas/${this.editandoId}`, tarefaAtualizada)
      .subscribe({
        next: () => {
          this.limparFormulario();
          this.cdr.detectChanges();
          this.buscarTarefas();

          this.mensagem = 'Tarefa atualizada com sucesso!';
          setTimeout(() => this.mensagem = '', 3000);
        },
        error: (err) => {
          console.error('Erro ao atualizar tarefa:', err);
        }
      });
  }

  deletarTarefa(id: string) {
    if (!confirm('Tem certeza que deseja excluir esta tarefa?')) {
      return;
    }

    this.http.delete(`http://localhost:5007/api/Tarefas/${id}`)
      .subscribe({
        next: () => {
          this.buscarTarefas();

          this.mensagem = 'Tarefa excluída com sucesso!';
          setTimeout(() => this.mensagem = '', 3000);
        },
        error: (err) => {
          console.error('Erro ao deletar tarefa:', err);
        }
      });
  }

  editarTarefa(tarefa: Tarefa) {
    this.editandoId = tarefa.id;
    this.novaTarefa = {
      titulo: tarefa.titulo,
      descricao: tarefa.descricao,
      status: tarefa.status
    };
  }

  cancelarEdicao() {
    this.limparFormulario();
    this.cdr.detectChanges();
  }

  limparFormulario() {
    this.editandoId = null;
    this.novaTarefa = {
      titulo: '',
      descricao: '',
      status: 1
    };
  }

  aplicarFiltro() {
    this.buscarTarefas();
  }

  obterTextoStatus(status: number): string {
    switch (status) {
      case 1:
        return 'Pendente';
      case 2:
        return 'Em andamento';
      case 3:
        return 'Concluída';
      default:
        return 'Desconhecido';
    }
  }
}
