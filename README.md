
# USP.TCC.ChatIA

## POC para o projeto de TCC

**Aluno**: Leonardo Storolli Doratho

**Curso**: MBA Gestão de Projetos

**Orientador**: 

**Data**:

**Universidade**:


**site de testes:** 
https://tcchat.azurewebsites.net/




### Para Validar os JSONL (dados de treinamento)
`pip install --upgrade openai `


Para analisar seus dados de treinamento com a ferramenta de preparação de dados, execute o comando Python a seguir. 


`openai tools fine_tunes.prepare_data -f <LOCAL_FILE>`

Essa ferramenta aceita arquivos nos seguintes formatos de dados, se eles contiverem um prompt e uma coluna/chave de conclusão:

- (CSV) Valores separados por vírgula
- Valores separados por tabulação (TSV)
- Pasta de trabalho do Microsoft Excel (XLSX)
- JSON (JavaScript Object Notation)
- Linhas JSON (JSONL)

Data de criação deste projeto: agost/23
Última atualização: out/23
