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
import { Abastecimento } from './abastecimento';


export interface AbastecimentoListaRetorno { 
    lista?: Array<Abastecimento> | null;
    totalRegistros?: number;
    paginaAtual?: number;
    tamanhoPagina?: number;
}

