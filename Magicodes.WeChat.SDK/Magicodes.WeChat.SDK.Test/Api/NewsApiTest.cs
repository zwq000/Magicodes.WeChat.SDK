﻿// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : NewsApiTest.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System.Collections.Generic;
using Magicodes.WeChat.SDK.Apis.Material;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Magicodes.WeChat.SDK.Helper;
using System.Drawing;
using System.IO;
using Magicodes.WeChat.SDK.Apis;

namespace Magicodes.WeChat.SDK.Test.Api
{
    [TestClass]
    public class NewsApiTest : ApiTestBase
    {
        private readonly MaterialApi api = WeChatApisContext.Current.MaterialApi;

        public NewsApiTest()
        {
        }

        [TestMethod]
        public void NewsApiTest_GetById()
        {
            //var testNews = db.Site_News.FirstOrDefault();
            //if (testNews == null)
            //{
            //    Assert.Fail("没有数据！");
            //}
            //var result = api.Get(testNews.MediaId);
            //if (!result.IsSuccess())
            //{
            //    Assert.Fail("获取多图文信息失败，返回结果如下：" + result.DetailResult);
            //}
        }

        [TestMethod]
        public void NewsApiTest_Get()
        {
            var type = Apis.Material.Enums.MaterialType.video;
            //aa5fe50648fb489a8083cdd203370470.jpg
            var result = api.Get(type);
            var tempResult = (OtherMaterialResult)result;
            var wr = new WebRequestHelper();
            if (!result.IsSuccess())
                Assert.Fail("获取多图文信息失败，返回结果如下：" + result.DetailResult);

        }

        [TestMethod]
        public void NewsGet()
        {
            //string id = "8jBK8ujsrMrVlS1rn-SMirVwC9oIk-QbSbxxkORbK0s";
            string id = "8jBK8ujsrMrVlS1rn-SMior82fEjXCJiq0IBK0GHOxo";
            var result = api.GetMaterialById<GetVideoMaterialResult>(id);
            if(!result.IsSuccess())
                Assert.Fail("获取多图文信息失败，返回结果如下：" + result.DetailResult);
            else
            {
                WebRequestHelper wr = new WebRequestHelper();
                var stream = wr.GetResponseImage(result.DownUrl);

                using (var filestream = new FileStream("E:\\" + result.Title, FileMode.Create))
                {
                    byte[] arr = new byte[1024];
                    int size = stream.Read(arr, 0, arr.Length);
                    while (size > 0)
                    {
                        filestream.Write(arr, 0, size);
                        size = stream.Read(arr, 0, arr.Length);
                    }
                }
            }
        }


        [TestMethod]
        public void NewsApiTest_Post()
        {
            //不能使用第三方的图片
            var model = new NewsPostModel
            {
                Articles = new List<NewsPostModel.ArticleInfo>
                {
                    new NewsPostModel.ArticleInfo
                    {
                        Author = "liwq",
                        Content =
                            "<p><img data-s=\"300,640\" data-type=\"png\" data-src=\"http://mmbiz.qpic.cn/mmbiz/SLeRFiaVmNAS3kOq3icjbfpz1GicHibTN4P9jicick8xyiaia8TMEzafuB4dSBfba5IdshdYX2qXJqBP689NMhPHuo3PsQ/0?wx_fmt=png\" data-ratio=\"0.7733812949640287\" data-w=\"\"  /><br  /></p><p><span style=\"line-height: 25.6px;\">“Magicodes.WeiChat，是由Magicode.WeiChat团队打造的一个基于ASP.NET &nbsp; MVC5微信业务快速开发与定制的开发框架。目的让微信业务开发与定制更快速、简单。”</span></p>",
                        ContentSourceUrl = "http://www.cnblogs.com/codelove/p/5306395.html",
                        Digest = "每周一小更，每月一大更。我们要做最好的微信快速定制开发框架。",
                        ShowCoverPic = 0,
                        ThumbMediaId = "HXIy1CJD5Qt12D9XBuSx0pXEqWaCbkwdYwCQ50spLlE",
                        Title = "版本历史"
                    },
                    new NewsPostModel.ArticleInfo
                    {
                        Author = "liwq",
                        Content =
                            "<p><img data-s=\"300,640\" data-type=\"png\" data-src=\"http://mmbiz.qpic.cn/mmbiz/SLeRFiaVmNAS3kOq3icjbfpz1GicHibTN4P9jicick8xyiaia8TMEzafuB4dSBfba5IdshdYX2qXJqBP689NMhPHuo3PsQ/0?wx_fmt=png\" data-ratio=\"0.7733812949640287\" data-w=\"\"  /><br  /></p><p><span style=\"line-height: 25.6px;\">“Magicodes.WeiChat，是由Magicode.WeiChat团队打造的一个基于ASP.NET &nbsp; MVC5微信业务快速开发与定制的开发框架。目的让微信业务开发与定制更快速、简单。”</span></p>",
                        ContentSourceUrl = "http://www.cnblogs.com/codelove/p/5306395.html",
                        Digest = "每周一小更，每月一大更。我们要做最好的微信快速定制开发框架。",
                        ShowCoverPic = 0,
                        ThumbMediaId = "HXIy1CJD5Qt12D9XBuSx0pXEqWaCbkwdYwCQ50spLlE",
                        Title = "版本历史"
                    },
                    new NewsPostModel.ArticleInfo
                    {
                        Author = "liwq",
                        Content =
                            "<div><img src=\"http://mmbiz.qpic.cn/mmbiz/SLeRFiaVmNAS3kOq3icjbfpz1GicHibTN4P9jicick8xyiaia8TMEzafuB4dSBfba5IdshdYX2qXJqBP689NMhPHuo3PsQ/0?wx_fmt=png\" /></div>",
                        ContentSourceUrl = "http://www.cnblogs.com/codelove/p/5306395.html",
                        Digest = "每周一小更，每月一大更。我们要做最好的微信快速定制开发框架。",
                        ShowCoverPic = 0,
                        ThumbMediaId = "HXIy1CJD5Qt12D9XBuSx0pXEqWaCbkwdYwCQ50spLlE",
                        Title = "版本历史"
                    },
                    new NewsPostModel.ArticleInfo
                    {
                        Author = "liwq",
                        Content =
                            "<div><img src=\"http://mmbiz.qpic.cn/mmbiz/SLeRFiaVmNAS3kOq3icjbfpz1GicHibTN4P9jicick8xyiaia8TMEzafuB4dSBfba5IdshdYX2qXJqBP689NMhPHuo3PsQ/0?wx_fmt=png\" /></div>",
                        ContentSourceUrl = "http://www.cnblogs.com/codelove/p/5306395.html",
                        Digest = "每周一小更，每月一大更。我们要做最好的微信快速定制开发框架。",
                        ShowCoverPic = 0,
                        ThumbMediaId = "HXIy1CJD5Qt12D9XBuSx0pXEqWaCbkwdYwCQ50spLlE",
                        Title = "版本历史"
                    }
                }
            };
            var result = api.Post(model);
            if (!result.IsSuccess())
                Assert.Fail("添加多图文信息失败，返回结果如下：" + result.DetailResult);
        }
    }
}