SELECT
    product_name,
    c.year,
    c.price
FROM Product
JOIN Sales AS c
ON c.product_id = Product.product_id

