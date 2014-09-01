Amazon Elastic Compute Cloud (Amazon EC2) - Limited Beta
2007-07-04T12:30:00
![](http://ec1.images-amazon.com/images/G/01/00/10/00/14/19/27/100014192753)Lately, I've been spending time with some of the Web services offered by Amazon (yeah, the same people who sell all those books). They have some interesting services like S3, which I use to host images on this site. I'm working on an S3 browser written in .NET 3.0 I'll release later this year.

Other services like [EC2](http://http://www.amazon.com/gp/browse.html?node=201590011) are even more interesting. Here's a description.

> Amazon EC2 presents a true virtual computing environment, allowing you to use web service interfaces to requisition machines for use, load them with your custom application environment, manage your network's access permissions, and run your image using as many or few systems as you desire. 
> 
> To use Amazon EC2, you simply:  

> 
>   * Create an Amazon Machine Image (AMI) containing your applications, libraries, data and associated configuration settings. Or use our pre-configured, templated images to get up and running immediately. 
>   * Upload the AMI into Amazon S3. Amazon EC2 provides tools that make storing the AMI simple. Amazon S3 provides a safe, reliable and fast repository to store your images. 
>   * Use Amazon EC2 web service to configure security and network access. 
>   * Use Amazon EC2 web service to start, terminate, and monitor as many instances of your AMI as needed. 
>   * Pay for the instance hours and bandwidth that you actually consume. 
> 
> **Service Highlights**
> 
>   * **Elastic**  
Amazon EC2 enables you to increase or decrease capacity within minutes, not hours or days. You can commission one, hundreds or even thousands of server instances simultaneously. Of course, because this is all controlled with web service APIs, your application can automatically scale itself up and down depending on its needs.  
  

>   * **Completely Controlled**  
You have complete control of your instances. You have root access to each one, and you can interact with them as you would any machine. Each instance predictably provides the equivalent of a system with a 1.7Ghz x86 processor, 1.75GB of RAM, 160GB of local disk, and 250Mb/s of network bandwidth.  
  

>   * **Designed for use with Amazon S3**  
Amazon EC2 works in conjunction with Amazon Simple Storage Service (Amazon S3) to provide a combined solution for computing and storage across a wide range of applications.  
  

>   * **Reliable**  
Amazon EC2 offers a highly reliable environment where replacement instances can be rapidly and reliably commissioned. The service runs within Amazon's proven network infrastructure and datacenters.  
  

>   * **Secure  
**Amazon EC2 provides web service interfaces to control network security. You define groups of instances and their desired accessibility.  
  

>   * **Inexpensive  
**Amazon EC2 passes on to you the financial benefits of Amazon's scale. You pay a very low rate for the compute capacity you actually consume. Compare this with the significant up-front expenditures traditionally required to purchase and maintain hardware, either in-house or hosted. This frees you from many of the complexities of capacity planning, transforms what are commonly large fixed costs into much smaller variable costs, and removes the need to over-buy "safety net" capacity to handle periodic traffic spikes. 
> 
> **Pricing**
> 
> Pay only for what you use. There is no minimum fee. 
> 
> _Instances  
_$0.10 per instance-hour consumed (or part of an hour consumed) 
> 
> _Data Transfer_  
$0.10 per GB - all data transfer in 
> 
> $0.18 per GB - first 10 TB / month data transfer out  
$0.16 per GB - next 40 TB / month data transfer out  
$0.13 per GB - data transfer out / month over 50 TB 

I really like this service model. It's pay as you go and expandable. I could see "startups" using these services. There's less infrastructure to design and support, high availability and if your idea catches fire, you have instant capacity growth.

Personally, I find myself using online services more and more for my own projects simply because it saves me from having to deal with hardware, computer upgrades, backups, etc. I'm slowly moving all of my family's online stoarge needs to S3. If I could get an online development environment with the same fedality as my desktop environment, I would switch in an instant.
