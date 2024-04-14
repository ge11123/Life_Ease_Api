# 專案架構

```
TodoList.WebApi/
├── TodoList.WebApi.sln                    # 解決方案檔案
├── src/                                   # 專案源代碼
│   ├── TodoList.Api/                      # ASP.NET Core Web API專案
│   │   ├── Controllers/                     # 控制器
│   │   ├── appsettings.json                 # 應用程式設定檔
│   │   ├── Program.cs                       # 應用程式進入點
│   │   └── ...
│   ├── TodoList.Application/              # 應用程式層
│   │   ├── Commands/                        # Command Object (Command)
│   │   │   ├── CreateTodoCommand.cs
│   │   │   └── ...
│   │   ├── DTOs/                            # 查詢對象
│   │   │   ├── TodoListDTO.cs
│   │   │   └── ...
│   │   ├── Handlers/                        # 處理器
│   │   │   ├── CreateTodoHandler.cs
│   │   │   ├── GetTodoListHandler.cs
│   │   │   └── ...
│   │   ├── Queries/                         # Query Object (Read)
│   │   │   ├── GetTodoListQuery.cs
│   │   │   └── ...
│   │   ├── Services/                        # 邏輯處理
│   │   │   ├── Interfaces/
│   │   │   ├── GetTodoListHandler.cs
│   │   │   └── ...
│   │   └── ...
│   ├── TodoList.Domain/                   # 領域層
│   │   ├── Entities/                        # 實體類別
|   |   |   ├── Todo.cs
│	│   │   └── ...
│   │   └── ...
│   └── TodoList.Infrastructure/           # 基礎設施層
│       ├── Repositories/                    # 資料存取邏輯
│       │   ├── Interfaces/              
│       │   └── ...
│       ├── Logging/                         # 日誌記錄
│       ├── ExternalServices/                # 外部服務連接
│       └── ...
├── tests/                                 # 測試專案
│   ├── TodoList.Tests.Unit/                 # 單元測試
│   └── TodoList.Tests.Integration/          # 整合測試
└── ...

```



# 代辦事項清單
1  依賴注入 (AutoMapper, MediatR, FluentValidation, Serilog, Swagger, EntityFrameworkCore, ...)
2. 驗證 (FluentValidation)
3. 日誌記錄 (Serilog)
4. 學習使用 (Record)
5. 撰寫 TodoList 的 CRUD 功能



