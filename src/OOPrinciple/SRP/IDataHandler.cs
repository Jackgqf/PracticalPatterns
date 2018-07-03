using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.OOPrinciple.SRP
{
    //数据处理操作：读取，格式化，写入目标环境


    #region 未分离职责接口设计(Unseparated responsibility interface design)

    //interface IDataHandler<TSource,TTarget>
    //{
    //    TSource Read();//Read from file or database?
    //    TTarget Format(TSource source);//To XML or binary data?
    //    void Write(TTarget graph);//write to database or message queue?
    //}

    #endregion

    #region 分离职责接口设计(Seperated responsibility interface design)

    interface IReader<TData>
    {
        TData Read();
    }

    interface IWriter<IData>
    {
        void Write(IData graph);
    }

    interface IDataFormatter<TSource, TTarget>
    {
        TTarget Format(TSource source);
    }

    interface IDataHandler<TSource, TTarget> :
        IReader<TSource>, IWriter<TTarget>, IDataFormatter<TSource, TTarget> { }

    #endregion
}
