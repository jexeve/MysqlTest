public class ViewData
{

    public static void ViewAllPosts()
    {
        using (var context = new MyDbContext())
        {
            // Consulta LINQ
            var todosLosPosts = context.Posts.ToList();

            Console.WriteLine($"Total de registros: {todosLosPosts.Count}");

            ShowData( todosLosPosts );

        }
    }

    public static void OrderAndDisplayPostsByDate()
    {
        using (var context = new MyDbContext())
        {
            // Consulta LINQ con OrderBy
            var orderedPosts = context.Posts.OrderBy(post => post.Date).ToList();

            Console.WriteLine("Esta ordenando desde mas antiguo a mas actual");

            ShowData( orderedPosts );

        }
    }

    public static void GroupByAuthor()
    {
        using (var context = new MyDbContext())            
        {
            var todosLosPosts = context.Posts.ToList();

            var groupedByAuthor = todosLosPosts.GroupBy(post => post.Author);

            foreach (var group in groupedByAuthor)
            {
                Console.WriteLine($"Autor: '{group.Key}' ha publicado {group.Count()}");                

                foreach (var post in group)
                {
                    Console.WriteLine($"Id: {post.Id}");
                    Console.WriteLine($"Titulo: {post.title}");
                    Console.WriteLine($"Descripcion: {post.description}");
                    Console.WriteLine($"Contenido: {post.content}");
                    Console.WriteLine($"Fecha publicacion: {post.Date}");
                    Console.WriteLine("------------------------------------------------------------------");
                }

                Console.WriteLine();
            }

        }
    }

    public static void QueryComplex()
    {
        using (var context = new MyDbContext())
        {
            // Consulta LINQ con WHERE, GROUP BY y ORDER BY
            var postTotalsByAuthor = context.Posts
                .Where(post => post.Date.Year == 2023) // Filtro con WHERE
                .GroupBy(post => post.Author)
                .OrderByDescending(group => group.Count()) // Ordenar por la cantidad de posts en orden descendente
                .Select(group => new { Author = group.Key, TotalPosts = group.Count() })
                .ToList();

            Console.WriteLine("Post agrupados por Autor publicados en el 2023");

            foreach (var result in postTotalsByAuthor)
            {
                Console.WriteLine($"El autor {result.Author} ha publicado {result.TotalPosts} Post");
            }
        }
    }

    public static void ShowData(List <Post> posts)
    {
        // Mostrar los detalles del post
        foreach (var post in posts)
        {
            Console.WriteLine($"Id: {post.Id}");
            Console.WriteLine($"Autor: {post.Author}");
            Console.WriteLine($"Titulo: {post.title}");
            Console.WriteLine($"Descripcion: {post.description}");
            Console.WriteLine($"Contenido: {post.content}");
            Console.WriteLine($"Fecha publicacion: {post.Date}");
            Console.WriteLine("------------------------------------------------------------------");
        }
    }

}
