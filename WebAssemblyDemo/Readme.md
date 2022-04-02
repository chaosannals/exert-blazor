# Blazor WebAssembly Demo

## 开发调试与发布

同时启动 前端开发服务器（WebAssemblyDemo） 和 后端服务器（BackendDemo）
开发时通过 BackendDemo 的服务器，反向代理到 WebAssemblyDemo 。（这个过程和一般的 Vue 开发脚手架是相反的）
发布时 通过 BackendDemo 静态发布 WebAssemblyDemo 编译后的文件，转发无文件路径到 index.html （这个过程和 Vue 的发布是一样的。）
