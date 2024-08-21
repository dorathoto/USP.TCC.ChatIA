<img alt="GitHub commit merge status" src="https://img.shields.io/github/commit-status/dorathoto/USP.TCC.ChatIA/stage/9eed5f547d743210f2b3589ffd574bfc931e44f4"> <img alt="GitHub License" src="https://img.shields.io/github/license/dorathoto/USP.TCC.ChatIA"> <img alt="GitHub commit activity" src="https://img.shields.io/github/commit-activity/y/dorathoto/USP.TCC.ChatIA"> <img alt="Language" src="https://img.shields.io/badge/language-C%23-blueviolet">





# USP.TCC.ChatIA

## Projeto de TCC

**Aluno**: Leonardo Storolli Dorathoto

**Curso**: MBA Gestão de Projetos

**Orientador**: José Carlos Curvelo Santana

**Data**: 2022-2024

**Universidade**: Poli USP Pro

**Linkedin**: [perfil](https://www.linkedin.com/in/doratiotto/)


**site do chatbot:** 
https://tcchat.azurewebsites.net/




### Para Validar os JSONL (dados de treinamento)
Versão 1.3 com openai

`pip install --upgrade openai `

Para analisar os dados de treinamento com a ferramenta de preparação de dados, execute o comando Python a seguir:

`openai tools fine_tunes.prepare_data -f <LOCAL_FILE>`

Essa ferramenta aceita arquivos nos seguintes formatos de dados, se eles contiverem um prompt e uma coluna/chave de conclusão:

- (CSV) Valores separados por vírgula
- Valores separados por tabulação (TSV)
- Pasta de trabalho do Microsoft Excel (XLSX)
- JSON (JavaScript Object Notation) - **preferencial**
- Linhas JSON (JSONL)

Data de criação deste projeto: agost/23

Última atualização: agosto/24


## Update método de aprendizagem. 
Após uma minuciosa avaliação, ficou evidente que um conjunto de 500 perguntas em um chat do tamanho de um Llama 2 não teria impacto significativo no nível de especialização desejado. Foi então criado 6.000 perguntas/respostas e no final terminou com 25.438 perguntas/respostas, porém apesar da melhora ainda não foi o suficiente. Diante dessa constatação, optou-se pelo desenvolvimento de uma nova ferramenta com inteligência artificial (IA) incorporada, cuja finalidade é gerar conteúdo para o treinamento da IA primária.

Embora tenho perdido em termos de qualidade, esta abordagem proporciona ganhos consideráveis em quantidade de documentos de treinamento, permitindo a geração fácil de milhares de perguntas e respostas. Essa estratégia visa superar a limitação da escala anterior, tornando o processo de aprendizado mais abrangente e eficiente.



## Stacks

 - ASP.NET .NET 8 - C# 12
 - Docker - compose
 - Microsoft Azure
 - Javascript -> PWA
 - Html5 & CSS3 (Sass)
 - LlaMa 2 - [sobre o Llama](https://llama.meta.com/)
 - OpenAI - Microsoft [OpenAI](https://learn.microsoft.com/pt-br/azure/ai-services/openai/overview)
-----------
 - Tempo estimado de desenvolvimento: 158h
 - Tempo estimado de treinamento: 62h
 - Tempo estimado de pesquisa: 40h
 - Tempo estimado para escrita do artigo: 30h
