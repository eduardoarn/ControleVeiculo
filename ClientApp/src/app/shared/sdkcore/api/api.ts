export * from './abastecimento.service';
import { AbastecimentoService } from './abastecimento.service';
export * from './motorista.service';
import { MotoristaService } from './motorista.service';
export * from './turnoLancamento.service';
import { TurnoLancamentoService } from './turnoLancamento.service';
export * from './veiculo.service';
import { VeiculoService } from './veiculo.service';
export const APIS = [AbastecimentoService, MotoristaService, TurnoLancamentoService, VeiculoService];
