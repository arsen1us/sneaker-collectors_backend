﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using sneaker_collectors_backend.Models;

namespace sneaker_collectors_backend.Services
{
    //public class ColorService : IDatabaseService<SneakerColor>
    //{
    //    SneakerCollectorsContext _database;

    //    public ColorService(SneakerCollectorsContext database)
    //    {
    //        _database = database;
    //    }
    //    // Добавить цвет

    //    public async Task AddAsync(SneakerColor color)
    //    {
    //        await _database.AddAsync(color);
    //        await _database.SaveChangesAsync();
    //    }
    //    // Получить цвет по id

    //    public async Task<SneakerColor> GetByIdAsync(string id)
    //    {
    //        if (await IsExists(id))
    //        {
    //            var color = await _database.SneakerColors.FirstOrDefaultAsync(c => c.Id == id);
    //            return color;
    //        }
    //        // Добавить обработку данной ситуации
    //        return null;
    //    }
    //    // Получить список всех цветов

    //    public async Task<List<SneakerColor>> GetAllAsync()
    //    {
    //        var allColors = await _database.SneakerColors.ToListAsync();
    //        return allColors;
    //    }

    //    // Удалить цвет

    //    public async Task RemoveAsync(string id)
    //    {
    //        var color = await GetByIdAsync(id);
    //        if (color != null)
    //        {
    //            _database.SneakerColors.Remove(color);
    //            await _database.SaveChangesAsync();
    //        }
    //        else
    //        {
    //            // Обработать ошибку
    //        }
    //    }
    //    // Обновить цвет

    //    public async Task UpdateAsync(SneakerColor color)
    //    {
    //        var existingColor = await _database.SneakerColors.FindAsync(color.Id);
    //        if (existingColor == null)
    //        {
    //            // Добавить обработку данной ситуэйшон
    //        }
    //        else
    //        {
    //            existingColor.Color = color.Color;
    //            await _database.SaveChangesAsync();
    //        }
    //    }
    //    // Проверить, существует ли цвет

    //    public async Task<bool> IsExists(string id)
    //    {
    //        if (await _database.SneakerColors.AnyAsync(c => c.Id == id))
    //            return true;
    //        return false;
    //    }
    //}
}
