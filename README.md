
# USP.TCC.ChatIA

## POC para o projeto de TCC

**Aluno**: Leonardo Storolli Doratho

**Curso**: MBA Gestão de Projetos

**Orientador**: José Carlos Curvelo Santana

**Data**: 2023-2024

**Universidade**: Poli USP Pro


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


## Update método de aprendizagem. 
Após uma minuciosa avaliação, ficou evidente que um conjunto de 1.000 perguntas em um chat do tamanho de um Llama 2 não teria impacto significativo no nível de especialização desejado. Diante dessa constatação, optou-se pelo desenvolvimento de uma nova ferramenta com inteligência artificial (IA) incorporada, cuja finalidade é gerar conteúdo para o treinamento da IA primária.

Embora tenhamos perdido em termos de qualidade, a abordagem adotada proporciona ganhos consideráveis em quantidade, permitindo a geração fácil de milhares de perguntas e respostas. Essa estratégia visa superar a limitação da escala anterior, tornando o processo de aprendizado mais abrangente e eficiente.
