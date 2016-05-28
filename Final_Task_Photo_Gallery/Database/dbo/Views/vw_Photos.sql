
CREATE VIEW [dbo].[vw_Photos]
AS
SELECT        p.ID, p.Name, p.Description, p.UploadDate, p.FileName, p.Owner, COALESCE (l.cnt, 0) AS Likes
FROM            dbo.Photos AS p LEFT OUTER JOIN
                             (SELECT        PhotoID, COUNT(*) AS cnt
                               FROM            dbo.Likes
                               GROUP BY PhotoID) AS l ON p.ID = l.PhotoID

