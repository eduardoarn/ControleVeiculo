/**
 * Gerenciamento de Veículos
 * Exemplo de API REST criada com o ASP.NET Core
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */
import { Motorista } from './motorista';


export interface MotoristaListaRetorno { 
    lista?: Array<Motorista> | null;
    totalRegistros?: number;
    paginaAtual?: number;
    tamanhoPagina?: number;
}
