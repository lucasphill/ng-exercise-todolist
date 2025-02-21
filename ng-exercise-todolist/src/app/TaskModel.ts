import { UUID } from "crypto";

export interface Task {
    id?: UUID,
    tarefa: string,
    categoria: string,
    concluido?: boolean
}